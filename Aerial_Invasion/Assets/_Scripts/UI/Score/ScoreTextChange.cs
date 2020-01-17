using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextChange : MonoBehaviour {

    public GameObject scoreText;

    public Sprite ballon;
    public Sprite survive;
    public Sprite blimp;

	void Start()
    {
        if (MissionHandler.mission.missionModeEnable)
        {
            if (MissionHandler.missionType.ballonKill == MissionHandler.mission.missionTypes)
            {
                scoreText.transform.position = new Vector3 (18.9f, 9.25f, -4.0f);
                scoreText.GetComponent<SpriteRenderer>().sprite = ballon;
            }

            if (MissionHandler.missionType.survive == MissionHandler.mission.missionTypes)
            {
                scoreText.transform.position = new Vector3 (20.45f, 9.25f, -4.0f);
                scoreText.GetComponent<SpriteRenderer>().sprite = survive;
            }

            if (MissionHandler.missionType.blimpKill == MissionHandler.mission.missionTypes)
            {
                scoreText.transform.position = new Vector3 (19.8f, 9.25f, -4.0f);
                scoreText.GetComponent<SpriteRenderer>().sprite = blimp;
            }
        }
	}
}
