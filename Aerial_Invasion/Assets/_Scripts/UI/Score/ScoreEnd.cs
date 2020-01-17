using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEnd : MonoBehaviour {

    public static int scorelerp = 0;
    private int highscorelerp= 0;
    private float inc = 0.0f;
    private float timeToReachMax = 0.0f;
    public float timeFormula = 10.0f;

    public GameObject[] nums = new GameObject[10];
    public Transform[] scorePos = new Transform[4];
    public Transform[] highScorePos = new Transform[4];

    private GameObject numClone1;
    private GameObject numClone10;
    private GameObject numClone100;
    private GameObject numClone1000;

    private GameObject highnumClone1;
    private GameObject highnumClone10;
    private GameObject highnumClone100;
    private GameObject highnumClone1000;

    void Start()
    {
        if (!MissionHandler.mission.missionModeEnable)
        {
            inc = 0.0f;
            numClone1 = (GameObject)Instantiate(nums[0], scorePos[0].position, scorePos[0].rotation);
            numClone1.transform.parent = gameObject.transform;

            if (Score.highScore == 0)
            {
                highnumClone1 = (GameObject)Instantiate(nums[0], highScorePos[0].position, highScorePos[0].rotation);
                highnumClone1.transform.parent = gameObject.transform;
            }

            else
            {
                highscorelerp = Score.highScore;
                DisplayHighScore(Score.highScore);
            }
        }
    }

    void Update()
    {
        if (GameOverScreen.gameOverMsgRdy && !MissionHandler.mission.missionModeEnable)
        {
            timeToReachMax = Score.score / timeFormula;
            inc += Time.deltaTime / timeToReachMax;
            scorelerp = (int)Mathf.Lerp(0, Score.score, inc);
            DisplayScore(scorelerp);

            if (scorelerp > highscorelerp)
            {
                highscorelerp = (int)Mathf.Lerp(0, Score.highScore, inc);
                DisplayHighScore(highscorelerp);
            }
        }
    }

    void TimeFormula()
    {

    }

    void DisplayScore(int value)
    {
        while (value > 0)
        {
            int digit = value % 10;

            if (value <= 9)
            {
                Destroy(numClone1);
                numClone1 = (GameObject)Instantiate(nums[digit], scorePos[0].position, scorePos[0].rotation);
                numClone1.transform.parent = gameObject.transform;
            }

            if (value > 9 && value <= 99)
            {
                Destroy(numClone10);
                numClone10 = (GameObject)Instantiate(nums[digit], scorePos[1].position, scorePos[1].rotation);
                numClone10.transform.parent = gameObject.transform;
            }

            if (value > 99 && value <= 999)
            {
                Destroy(numClone100);
                numClone100 = (GameObject)Instantiate(nums[digit], scorePos[2].position, scorePos[2].rotation);
                numClone100.transform.parent = gameObject.transform;
            }

            if (value > 999 && value <= 9999)
            {   
                Destroy(numClone1000);
                numClone1000 = (GameObject)Instantiate(nums[digit], scorePos[3].position, scorePos[3].rotation);
                numClone1000.transform.parent = gameObject.transform;
            }

            value /= 10;
        }
    }

    void DisplayHighScore(int value)
    {
        while (value > 0)
        {
            int digit = value % 10;

            if (value <= 9)
            {
                Destroy(highnumClone1);
                highnumClone1 = (GameObject)Instantiate(nums[digit], highScorePos[0].position, highScorePos[0].rotation);
                highnumClone1.transform.parent = gameObject.transform;
            }

            if (value > 9 && value <= 99)
            {
                Destroy(highnumClone10);
                highnumClone10 = (GameObject)Instantiate(nums[digit], highScorePos[1].position, highScorePos[1].rotation);
                highnumClone10.transform.parent = gameObject.transform;
            }

            if (value > 99 && value <= 999)
            {
                Destroy(highnumClone100);
                highnumClone100 = (GameObject)Instantiate(nums[digit], highScorePos[2].position, highScorePos[2].rotation);
                highnumClone100.transform.parent = gameObject.transform;
            }

            if (value > 999 && value <= 9999)
            {   
                Destroy(highnumClone1000);
                highnumClone1000 = (GameObject)Instantiate(nums[digit], highScorePos[3].position, highScorePos[3].rotation);
                highnumClone1000.transform.parent = gameObject.transform;
            }

            value /= 10;
        }
    }
}
