using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;

    private float offsetX;

	void Start () 
    {
        offsetX = transform.position.x - player.position.x;
	}

	void Update()
    {
        if (MissionHandler.mission.missionWin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        else if (!PlayerController.dead)
        {
            transform.position = new Vector3(player.position.x + offsetX, transform.position.y, transform.position.z);
        }

        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
	}
}
