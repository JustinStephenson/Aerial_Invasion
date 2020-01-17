using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuButton : MonoBehaviour {

    public void MainMenu()
    {
        if (PlayerController.dead && GameOverScreen.gameOverMsgRdy)
        {
            if (!MissionHandler.mission.missionModeEnable)
            {
                MenuSounds.sound.menuSound = true;
                FindObjectOfType<BannerAdd>().bannerView.Destroy();
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                for (int i = 0; i < GameControl.control.missionOn.Length; i++)
                {
                    GameControl.control.missionOn[i] = 0;
                }
                MenuSounds.sound.menuSound = true;
                FindObjectOfType<BannerAdd>().bannerView.Destroy();
                SceneManager.LoadScene("MissionMode");
            }
        }
    }
}