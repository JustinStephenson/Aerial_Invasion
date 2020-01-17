using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MissionPopUp : MonoBehaviour {

    public GameObject[] buttons;

    public static bool called;
    public GameObject scroll;

    public GameObject frontText;
    public GameObject backText;
    public Sprite destroy;
    public Sprite ballon;
    public Sprite survive;
    public Sprite seconds;
    public Sprite blimp;

    public Sprite[] nums = new Sprite[10];
    public GameObject[] valuePos = new GameObject[3];

    public static int ballonKillCount;
    public static int surviveTime;
    public static int blimpKillCount;

    private Canvas myCanvas;

    void Update()
    {
        if (called)
        {
            myCanvas = GetComponent<Canvas>();

            //disables buttons.
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<ButtonMission>().enabled = false;
            }
            scroll.GetComponent<ScrollRect>().enabled = false;
            BackButton.backButton = false;

            //changes text based on mission selected
            if (MissionHandler.missionType.ballonKill == MissionHandler.mission.missionTypes)
            {
                frontText.GetComponent<Image>().sprite = destroy;
                backText.GetComponent<Image>().sprite = ballon;
                DisplayValue(ballonKillCount);
            }

            if (MissionHandler.missionType.survive == MissionHandler.mission.missionTypes)
            {
                frontText.GetComponent<Image>().sprite = survive;
                backText.GetComponent<Image>().sprite = seconds;
                DisplayValue(surviveTime);
            }

            if (MissionHandler.missionType.blimpKill == MissionHandler.mission.missionTypes)
            {
                frontText.GetComponent<Image>().sprite = destroy;
                backText.GetComponent<Image>().sprite = blimp;
                DisplayValue(blimpKillCount);
            }

            called = false;
        }
    }

    public void YesPress()
    {
        MenuSounds.sound.menuSound = true;

        //enables buttons.
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<ButtonMission>().enabled = true;
        }
        scroll.GetComponent<ScrollRect>().enabled = true;
        myCanvas.enabled = false;

        MissionHandler.mission.missionModeEnable = true;
        BackButton.backButton = true;

        //Changes to game playing Scene.
        SceneManager.LoadScene("Main");
    }

    public void NoPress()
    {
        MenuSounds.sound.menuSound = true;

        //enables buttons.
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<ButtonMission>().enabled = true;
        }
        scroll.GetComponent<ScrollRect>().enabled = true;

        //reset display value and position on no press
        valuePos[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(-14.0f, 0.0f, 0.0f);
        valuePos[1].GetComponent<RectTransform>().anchoredPosition = new Vector3(12.0f, 0.0f, 0.0f);

        valuePos[0].GetComponent<Image>().enabled = false;
        valuePos[1].GetComponent<Image>().enabled = false;
        valuePos[2].GetComponent<Image>().enabled = false;

        //Diable the mission I am on
        for (int i = 0; i < GameControl.control.missionOn.Length; i++)
        {
            GameControl.control.missionOn[i] = 0;
        }
        BackButton.backButton = true;
        myCanvas.enabled = false;
    }

    public void DisplayValue(int value)
    {       
        int x = 0;

        if (value <= 9)
        {
            x = 1;
        }
        else
        {
            x = 0;
        }

        if (value > 9 && value <= 99)
        {
            valuePos[0].GetComponent<RectTransform>().anchoredPosition = new Vector3 (0.0f, 0.0f, 0.0f);
            valuePos[1].GetComponent<RectTransform>().anchoredPosition = new Vector3 (26.0f, 0.0f, 0.0f);
        }

        while (value > 0)
        {           
            int digit = value % 10;

            if (value <= 9)
            {
                valuePos[x].GetComponent<Image>().enabled = true;
                valuePos[x].GetComponent<Image>().sprite = nums[digit];
            }

            if (value > 9 && value <= 99)
            {
                valuePos[1].GetComponent<Image>().enabled = true;
                valuePos[1].GetComponent<Image>().sprite = nums[digit];;
            }

            if (value > 99 && value <= 999)
            {
                valuePos[2].GetComponent<Image>().enabled = true;
                valuePos[2].GetComponent<Image>().sprite = nums[digit];
            }

            value /= 10;
        }
    }
}
