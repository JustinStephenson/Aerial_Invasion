using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlimpController : MonoBehaviour {

    public float blimpActionOffset = 0.0f;
    public float moveSpeed = 0.0f;

    private bool blimpSpawn = true;
    private bool blimpUp = false;
    private bool blimpDown = false;

    private PlayerController player = null;
    private SpawnController spawnPerm = null;

    public float blimpFireSpeed = 0.0f;
    private float blimpNextShot = 0.0f;
    private Vector3 blimpShotPos;

    private AudioSource myAudio;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        spawnPerm = FindObjectOfType<SpawnController>();
        myAudio = GetComponent<AudioSource>();
    }

	void Update()
    {
        if (player == null)
        {
            return;
        }

        if (PlayerController.dead)
        {
            return;
        }

        else
        {
            if (transform.position.x <= player.transform.position.x + blimpActionOffset)
            {
                // Follows Player on X axis.
                transform.position = new Vector3(player.transform.position.x + blimpActionOffset, transform.position.y, transform.position.z);
            
                if (blimpSpawn)
                {
                    transform.Translate(Vector3.down * moveSpeed);
                }

                if (transform.position.y <= spawnPerm.enemyMinHeight.position.y)
                {
                    blimpSpawn = false;
                    blimpDown = false;
                    blimpUp = true;
                }

                if (transform.position.y >= spawnPerm.enemyMaxHeight.position.y + 1.0f)
                {
                    blimpSpawn = false;
                    blimpUp = false;
                    blimpDown = true;
                }

                if (blimpUp)
                {
                    transform.Translate(Vector3.up * moveSpeed);
                }

                if (blimpDown)
                {
                    transform.Translate(Vector3.down * moveSpeed);
                }


                if (Time.time > blimpNextShot)
                {
                    blimpNextShot = Time.time + blimpFireSpeed;

                    // follows blimp to find cannon to spawn shots.
                    blimpShotPos = new Vector3(transform.position.x - 1.5f, transform.position.y - 1.285f, transform.position.z);

                    myAudio.Play();
                    Instantiate(spawnPerm.blimpShot, blimpShotPos, transform.rotation);
                }
            }
        }
	}
}
