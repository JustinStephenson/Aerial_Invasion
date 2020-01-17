using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreFunction : MonoBehaviour {

    private PlayerController player = null;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

	void Update()
    {
        if (MissionHandler.mission.missionWin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        else if (!PlayerController.dead)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }

        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
