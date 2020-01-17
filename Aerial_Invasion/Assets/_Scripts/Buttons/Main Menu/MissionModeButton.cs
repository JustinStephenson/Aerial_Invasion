using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MissionModeButton : MonoBehaviour {

    public void MissonMode()
    {
        MenuSounds.sound.menuSound = true;
        FindObjectOfType<BannerAdd>().bannerView.Destroy();
        SceneManager.LoadScene("MissionMode");
    }
}
