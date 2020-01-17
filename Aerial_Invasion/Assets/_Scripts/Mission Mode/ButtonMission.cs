using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonMission : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public GameObject buttonHandler;

    public Canvas popCanvas;

    public Sprite noHighlight;

    public int coinWin = 0;

    public int missionNum = 0;
    public bool missionComplete;

    public bool mtBallons = false;
    public bool mtSurvive = false;
    public bool mtBlimps = false;

    public int mtBallonsCount = 0;
    public float mtSurviveTime = 0;
    public int mtBlimpsCount = 0;

    private bool dragging = false;
    private ScrollRect scrollRectParent;

    void Awake()
    {
        scrollRectParent = GetComponentInParent<ScrollRect>();
    }

    void Start()
    {
        if (missionComplete)
            {
                Image myImage = GetComponent<Image>();
                myImage.color = new Color32(100,100,100,225);
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
            SelectMission();
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
        popCanvas.enabled = true;
        MissionPopUp.called = true;
    }  

    public void SelectMission()
    {
        GameControl.control.missionOn[missionNum] = 1;
        GameControl.control.coinToWinMission = coinWin;

        if (mtBallons)
        {
            MissionHandler.mission.missionTypes = MissionHandler.missionType.ballonKill;
            MissionHandler.mission.missionBallonsTotal = mtBallonsCount;
            MissionPopUp.ballonKillCount = mtBallonsCount;
        }
        if (mtSurvive)
        {
            MissionHandler.mission.missionTypes = MissionHandler.missionType.survive;
            MissionHandler.mission.missionSurviveTime = mtSurviveTime;
            MissionPopUp.surviveTime = (int)mtSurviveTime;
        }
        if (mtBlimps)
        {
            MissionHandler.mission.missionTypes = MissionHandler.missionType.blimpKill;
            MissionHandler.mission.missionBlimpTotal = mtBlimpsCount;
            MissionPopUp.blimpKillCount = mtBlimpsCount;
        }
    }
}
