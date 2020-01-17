using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXButton : MonoBehaviour {

    public AudioMixer masterMixer;
    private bool soundSet = true;

	public void SFXSwitch () 
    {
        if (GameControl.control.sfxSound)
        {
            soundSet = false;
        }

        if (!GameControl.control.sfxSound)
        {
            soundSet = true;
        }

        GameControl.control.sfxSound = soundSet;
        GameControl.control.SoundLoad();
	}
}
