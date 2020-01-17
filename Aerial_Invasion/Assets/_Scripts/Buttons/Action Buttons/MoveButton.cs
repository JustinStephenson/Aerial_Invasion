using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour {

    public void Move()
    {
        if (!PlayerController.dead && PlayerController.canButtonMove)
        {
            PlayerController.moveButton = true;
        }
    }

    public void StartGame()
    {
        if (StartScreen.screenActive)
        {
            StartScreen.screenButton = true;

            if (MissionHandler.mission.missionModeEnable && MissionHandler.mission.missionTypes == MissionHandler.missionType.survive)
            {
                Score.startMissionTimer = true;
            }
        }
    }
}
