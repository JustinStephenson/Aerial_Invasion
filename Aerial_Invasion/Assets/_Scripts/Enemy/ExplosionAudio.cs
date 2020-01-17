using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAudio : MonoBehaviour {

    private AudioSource myAudio;

	void Start () 
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.Play();
	}
}
