using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonHighlight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public GameObject buttonHandler;

    public Canvas popCanvas;

    public Sprite noHighlight;
    public Sprite yesHighlight;

    public int skinNum = 0;
    private int skinloop = 0;

    public bool unlocked;
    private int unlockNum = 0;

    public int coinCost = 0;
    public static bool coinUsed = false;

    private bool dragging = false;
    private ScrollRect scrollRectParent;

    void Awake()
    {
        scrollRectParent = GetComponentInParent<ScrollRect>();
    }

    void Start()
    {
        if (skinNum == GameControl.control.skinNum)
        {
            DisableSkins();
            Image myImage = GetComponent<Image>();
            myImage.sprite = yesHighlight;
        }
    }

    public void OnPointerDown(PointerEventData eventdata)
    {

    }

    public void OnPointerUp(PointerEventData eventdata)
    {
        if (!dragging)
        {
            MenuSounds.sound.menuSound = true;
            Highlight();
        }
    }

    public void OnBeginDrag(PointerEventData eventdata)
    {
        scrollRectParent.OnBeginDrag(eventdata);
    }

    public void OnDrag(PointerEventData eventdata)
    {
        dragging = true;
        scrollRectParent.OnDrag(eventdata);
    }

    public void OnEndDrag(PointerEventData eventdata)
    {
        dragging = false;
        scrollRectParent.OnEndDrag(eventdata);
    }

    public void Highlight()
    {
        if (!unlocked)
        {
            popCanvas.enabled = true;
            PopUpMessage.called = true;
            PopUpMessage.buttonNum = skinNum;
        }

        else
        {
            skinloop = 0;

            //Disables all childern sprite reneders.
            DisableSkins();

            //Gives selected button the sprite baorder.
            Image myImage = GetComponent<Image>();
            myImage.sprite = yesHighlight;

            //Tells Gamecontrol to point to desired skin.
            while (skinloop < GameControl.control.skin.Length)
            {
                GameControl.control.skin[skinloop] = false;
                skinloop++;
            }

            GameControl.control.skin[skinNum] = true;
            GameControl.control.skinNum = skinNum;
        }
    }

    public void DisableSkins()
    {
        Image[] rend = buttonHandler.GetComponentsInChildren<Image>();
        ButtonHighlight[] bh = buttonHandler.GetComponentsInChildren<ButtonHighlight>();
        foreach (Image x in rend)
        {
                if (bh[unlockNum].unlocked)
                {
                    x.sprite = noHighlight;
                }
            unlockNum++;
        }
        unlockNum = 0;
    }
}
