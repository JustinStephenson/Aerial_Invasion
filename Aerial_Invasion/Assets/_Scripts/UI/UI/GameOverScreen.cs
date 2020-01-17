using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour {

    public Transform gameOverText;
    public Transform gameOverMessage;
    public Transform missionCompleteText;
    public Transform missionOverMessage;
    public float moveSpeed = 0.0f;

    static public bool gameOverMsgRdy = false;

    private PlayerController player;

	void Start () 
    {   
       player = FindObjectOfType<PlayerController>();
       gameOverMsgRdy = false;
	}

	void Update()
    {
        if (MissionHandler.mission.missionWin)
        {
            //Destroys all enemy gameobjects after a mission is completed
            GameObject[] allEnem = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject x in allEnem)
            {
                Destroy(x);
            }

            if (missionCompleteText.transform.position.y != 2.0f)
            {
                missionCompleteText.transform.Translate(Vector3.down * moveSpeed);
            }
        }

        if (!PlayerController.dead && !MissionHandler.mission.missionWin)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }

        if (PlayerController.deathCD <= 3.5f)
        {
            if (gameOverText.transform.position.y != 6.5f)
            {
                gameOverText.transform.Translate(Vector3.down * moveSpeed);
            }
        }

        if (!MissionHandler.mission.missionModeEnable)
        {
            if (PlayerController.deathCD <= 3.0f)
            {
                if (gameOverMessage.transform.position.y != 0.0f)
                {
                    gameOverMessage.transform.Translate(Vector3.up * moveSpeed);
                }
                else
                {
                    gameOverMsgRdy = true;
                }
            }
        }
        else
        {
            if (PlayerController.deathCD <= 3.0f)
            {
                if (missionOverMessage.transform.position.y != 0.0f)
                {
                    missionOverMessage.transform.Translate(Vector3.up * moveSpeed);
                }
                else
                {
                    gameOverMsgRdy = true;
                }
            }
        }
    }
}

