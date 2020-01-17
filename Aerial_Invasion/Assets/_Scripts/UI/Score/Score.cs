using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    static public int score = 0;
    static public int highScore = 0;
    private int tempScore = 0;

    //For ballon mission.
    private int tempBallonKillCount = 0;

    //For survive mission.
    static public bool startMissionTimer = false;
    private float missionTime = 0;
    private float tempMissionTime = 0;

    //for blimp mission.
    private int tempBlimpKillCount = 0;

    public GameObject[] nums = new GameObject[10];
    public Transform[] scorePos = new Transform[4];
    public Transform[] highScorePos = new Transform[4];

    private GameObject numClone1;
    private GameObject numClone10;
    private GameObject numClone100;
    private GameObject numClone1000;

    void Awake()
    {
        numClone1 = (GameObject)Instantiate(nums[0], scorePos[0].position, scorePos[0].rotation);
        numClone1.transform.parent = gameObject.transform;

        highScore = GameControl.control.highScore;

        if (MissionHandler.mission.missionModeEnable && MissionHandler.mission.missionTypes == MissionHandler.missionType.survive)
        {
            missionTime = MissionHandler.mission.missionSurviveTime;
            tempMissionTime = (int)MissionHandler.mission.missionSurviveTime;

            DisplayScore((int)missionTime);
        }
    }

	void Update()
    {
        if (MissionHandler.mission.missionModeEnable)
        {
            if (MissionHandler.mission.missionTypes == MissionHandler.missionType.ballonKill)
            {
                if (MissionHandler.mission.ballonKillCount > tempBallonKillCount)
                {
                    DisplayScore(MissionHandler.mission.ballonKillCount);
                    tempBallonKillCount = MissionHandler.mission.ballonKillCount;
                }
            }

            if (MissionHandler.mission.missionTypes == MissionHandler.missionType.survive)
            {
                if (PlayerController.dead)
                {
                    startMissionTimer = false;
                }

                if (startMissionTimer)
                {
                    MissionHandler.mission.surviveTimeRemaining += Time.deltaTime;
                    missionTime -= Time.deltaTime;

                    if (missionTime < tempMissionTime)
                    {
                        DisplayScore((int)missionTime);
                        tempMissionTime = missionTime;

                        if (missionTime <= 0)
                        {
                            startMissionTimer = false;
                        }
                    }
                }
            }

            if (MissionHandler.mission.missionTypes == MissionHandler.missionType.blimpKill)
            {
                if (MissionHandler.mission.blimpKillCount > tempBlimpKillCount)
                {
                    DisplayScore(MissionHandler.mission.blimpKillCount);
                    tempBlimpKillCount = MissionHandler.mission.blimpKillCount;
                }
            }

        }

        else
        {
            if (score > highScore)
            {
                highScore = score;
                GameControl.control.highScore = highScore;
            }

            if (score > tempScore)
            {
                DisplayScore(score);
                tempScore = score;
            }
        }
    }

    void OnDestroy()
    {
       score = 0;
    }

    void DisplayScore(int value)
    {
        bool[] used = new bool[4];

        if (value == 0)
        {
            Destroy(numClone1);
            numClone1 = (GameObject)Instantiate(nums[0], scorePos[0].position, scorePos[0].rotation);
            numClone1.transform.parent = gameObject.transform;
        }

        while (value > 0)
        {
            int digit = value % 10;

            if (value <= 9)
            {
                Destroy(numClone1);
                numClone1 = (GameObject)Instantiate(nums[digit], scorePos[0].position, scorePos[0].rotation);
                numClone1.transform.parent = gameObject.transform;
                used[0] = true;
            }

            if (value > 9 && value <= 99)
            {
                Destroy(numClone10);
                numClone10 = (GameObject)Instantiate(nums[digit], scorePos[1].position, scorePos[1].rotation);
                numClone10.transform.parent = gameObject.transform;
                used[1] = true;
            }
            else if (value <= 9 && !used[1])
            {
                Destroy(numClone10);
            }

            if (value > 99 && value <= 999)
            {
                Destroy(numClone100);
                numClone100 = (GameObject)Instantiate(nums[digit], scorePos[2].position, scorePos[2].rotation);
                numClone100.transform.parent = gameObject.transform;
                used[2] = true;
            }
            else if (value <= 99 && !used[2])
            {
                Destroy(numClone100);
            }

            if (value > 999 && value <= 9999)
            {   
                Destroy(numClone1000);
                numClone1000 = (GameObject)Instantiate(nums[digit], scorePos[3].position, scorePos[3].rotation);
                numClone1000.transform.parent = gameObject.transform;
                used[3] = true;
            }
            else if (value <= 999 && !used[3])
            {
                Destroy(numClone1000);
            }

            value /= 10;
        }
    }
}
        
