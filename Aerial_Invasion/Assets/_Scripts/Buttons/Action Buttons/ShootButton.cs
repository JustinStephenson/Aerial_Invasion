using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButton : MonoBehaviour {

    public void ShootStart()
    {
        if (!PlayerController.dead && !StartScreen.screenActive)
        {
            if (!PlayerController.shootWait)
            {
                PlayerController.shootButton = true;
            }
        }
    }
}
