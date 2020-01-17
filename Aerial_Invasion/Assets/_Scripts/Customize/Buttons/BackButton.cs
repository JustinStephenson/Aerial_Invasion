using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackButton : MonoBehaviour {

    public static bool backButton = true;

    public void MainMenu()
    {
        if (backButton)
        {
            MenuSounds.sound.menuSound = true;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
