using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CustomizeButton : MonoBehaviour {

    public void Customize()
    {
        MenuSounds.sound.menuSound = true;
        FindObjectOfType<BannerAdd>().bannerView.Destroy();
        SceneManager.LoadScene("Customize");
    }
}
