using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicColor : MonoBehaviour {

    public AudioMixer masterMixer;

    void Update()
    {
        if (GameControl.control.musicSound)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color32(100, 100, 100, 225);
        }
    }
}