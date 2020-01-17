using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicButton : MonoBehaviour {

    public AudioMixer masterMixer;
    private bool soundSet = true;

	public void MusicSwitch()
    {
        if (GameControl.control.musicSound)
        {
            soundSet = false;
        }

        if (!GameControl.control.musicSound)
        {
            soundSet = true;
        }

        GameControl.control.musicSound = soundSet;
        GameControl.control.SoundLoad();
	}
}
