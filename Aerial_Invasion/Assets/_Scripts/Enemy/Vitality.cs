using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitality : MonoBehaviour {

    public int maxHealth = 0;
    public bool hotAirBallon = false;
    public bool hotAirBallonPlusScore = false;
    public bool blimp = false;

    void Update()
    {
        if (maxHealth == 0)
        {
            Death();
        }
    }

    void Damage(int dmg)
    {
        maxHealth -= dmg;
    }

    void Death()
    {
        Destroy(gameObject);

        if (!PlayerController.dead)
        {
            if (hotAirBallon)
            {
                Score.score += 1;

                if (MissionHandler.mission.missionModeEnable && MissionHandler.mission.missionTypes == MissionHandler.missionType.ballonKill)
                {
                   MissionHandler.mission.ballonKillCount++;
                }
            }

            if (hotAirBallonPlusScore)
            {
 
                Score.score += 3;

                if (MissionHandler.mission.missionModeEnable && MissionHandler.mission.missionTypes == MissionHandler.missionType.ballonKill)
                {
                   MissionHandler.mission.ballonKillCount++;
                }
            }

            if (blimp)
            {
                Score.score += 5;

                if (MissionHandler.mission.missionModeEnable && MissionHandler.mission.missionTypes == MissionHandler.missionType.blimpKill)
                {
                   MissionHandler.mission.blimpKillCount++;
                }
            }
        }
    }
}
