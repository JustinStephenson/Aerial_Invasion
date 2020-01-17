using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {

    private Animator myAnim;

    void Start()
    {
        myAnim = GetComponent<Animator>();

        for (int i = 0; i < GameControl.control.skin.Length; i++)
        {
            if (GameControl.control.skin[i])
            {
                myAnim.SetBool("Skin" + i, true);
            }
        }
    }
}
