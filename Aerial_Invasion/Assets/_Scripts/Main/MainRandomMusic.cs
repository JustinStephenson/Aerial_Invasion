using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRandomMusic : MonoBehaviour {

    private AudioSource myAudio;
    public AudioClip[] soundTrack;

	void Start () 
    {
        myAudio = GetComponent<AudioSource>();

        int randNum = Random.Range(0,soundTrack.Length);
        myAudio.clip = soundTrack[randNum];
        myAudio.Play();
	}
}
