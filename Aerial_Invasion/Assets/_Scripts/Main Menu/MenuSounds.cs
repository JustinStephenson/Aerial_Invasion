using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour {

    private AudioSource myAudio;

    public static MenuSounds sound;

    public bool menuSound = false;

    void Awake()
    {
        if (sound == null)
        {
            DontDestroyOnLoad(gameObject);
            sound = this;
        }
        else if (sound != this)
        {
            Destroy(gameObject);
        }
    }

	void Start () 
    {
        myAudio = GetComponent<AudioSource>();
        GameControl.control.SoundLoad();
	}

    void Update()
    {
        if (menuSound)
        {
            myAudio.Play();
            menuSound = false;
        }
    }
}
