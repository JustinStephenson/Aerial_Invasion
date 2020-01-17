using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour {

    private PlayerController player = null;

    private AudioSource myAudio;

    private bool playOnce = false;

    void Awake()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        myAudio = GetComponent<AudioSource>();
    }

	void Start () 
    {
        player = FindObjectOfType<PlayerController>();
	}

	void Update()
    {
        transform.position = new Vector3(player.transform.position.x, -2.55f, -2.0f);

        if (PlayerController.deadGround)
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            if (!playOnce)
            {
                myAudio.Play();
                playOnce = true;
            }
        }
	}
}

