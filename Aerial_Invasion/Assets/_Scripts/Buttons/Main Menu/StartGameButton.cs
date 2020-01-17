using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGameButton : MonoBehaviour {

    public void StartGame()
    {
        MenuSounds.sound.menuSound = true;
        FindObjectOfType<BannerAdd>().bannerView.Destroy();
        SceneManager.LoadScene("Main");
    }
}
