using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour {

    public GameObject sc;
    public GameObject player;

    public static bool screenActive = false;
    public static bool screenButton = false;

	void Start()
    {
        screenActive = true;
        screenButton = false;
    }

	void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 1.0f, transform.position.y, transform.position.z);
        
        if (screenButton)
        {
            screenActive = false;
            screenButton = false;

            Component[] rend = GetComponentsInChildren<SpriteRenderer>();
            foreach (Component x in rend)
            {
                x.GetComponent<SpriteRenderer>().enabled = false;
            }

            sc.GetComponent<SpawnController>().enabled = true;
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<StartScreenMovement>().enabled = false;
        }
	}
}
