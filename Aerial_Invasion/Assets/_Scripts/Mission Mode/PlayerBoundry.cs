using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerBoundry : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        //Only will occur if the Player wins a mission.
        if (other.gameObject.CompareTag("Player"))
        {
            MissionHandler.mission.missionModeEnable = false;
            FindObjectOfType<BannerAdd>().bannerView.Destroy();
            SceneManager.LoadScene("MissionMode");
        }
    }
}
