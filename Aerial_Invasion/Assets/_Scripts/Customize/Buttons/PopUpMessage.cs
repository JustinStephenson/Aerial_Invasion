using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PopUpMessage : MonoBehaviour {

    public GameObject[] buttons;
    public static int buttonNum;

    public static bool called;
    public GameObject scroll;

    private Canvas myCanvas;

    public Image noText;
    public Image enoughText;
    public Image coinsText;
    private bool waitForText = false;

	void Update()
    {
        if (called)
        {
            myCanvas = GetComponent<Canvas>();

            //disables buttons.
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<ButtonHighlight>().enabled = false;
            }
            scroll.GetComponent<ScrollRect>().enabled = false;
            BackButton.backButton = false;
            called = false;
        }
	}
    
	public void YesPress()
    {
        MenuSounds.sound.menuSound = true;

        if (buttons[buttonNum].GetComponent<ButtonHighlight>().coinCost <= GameControl.control.coins)
        {
            buttons[buttonNum].GetComponent<ButtonHighlight>().unlocked = true;

            GameControl.control.coins -= buttons[buttonNum].GetComponent<ButtonHighlight>().coinCost;
            ButtonHighlight.coinUsed = true;
            GameControl.control.buttonUnlocks[buttonNum] = 1;
            buttons[buttonNum].GetComponent<ButtonHighlight>().Highlight();

            //enables buttons.
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<ButtonHighlight>().enabled = true;
            }
            scroll.GetComponent<ScrollRect>().enabled = true;

            BackButton.backButton = true;
            myCanvas.enabled = false;
        }
        else
        {
            EnableText();
            if (!waitForText)
            {
                waitForText = true;
                Invoke("DisableText", 1.5f);
            }
            NoPress();
            myCanvas.enabled = false;
        }
	}

    public void NoPress()
    {
        MenuSounds.sound.menuSound = true;

        //enables buttons.
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<ButtonHighlight>().enabled = true;
        }
        scroll.GetComponent<ScrollRect>().enabled = true;
        BackButton.backButton = true;
        myCanvas.enabled = false;
    }

    void EnableText()
    {
        noText.enabled = true;
        enoughText.enabled = true;
        coinsText.enabled = true;
    }

    void DisableText()
    {
        noText.enabled = false;
        enoughText.enabled = false;
        coinsText.enabled = false;
        waitForText = false;
    }
}