using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TryAgainButton : MonoBehaviour {

    public void TryAgain()
    {
        if (PlayerController.dead && GameOverScreen.gameOverMsgRdy)
        {
            MenuSounds.sound.menuSound = true;
            FindObjectOfType<BannerAdd>().bannerView.Destroy();
            SceneManager.LoadScene("Main");
        }
    }
}
