using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public Transform enemySpawnPoint;
    public Transform enemyMaxHeight;
    public Transform enemyMinHeight;
    public GameObject blimp;
    public GameObject hotAirBallon;
    public GameObject hotAirBallonPlusScore;

    public float spawnRate = 0.0f;

    public int numBeforeBlimpSpawn = 0;

    private float nextSpawn = 0.0f;
    private int hotAirBallonCount = 0;
    private int hotAirBallonTotal = 0;

    private int maxScoreBallonRange = 11;
    private int minScoreBallonRange = 1;

    //Blimp shot Gameobject
    public GameObject blimpShot;

    //incerasing deifficulty.
    private float intervalSpawnRate = 0.0f;
    public float maxSpawnRate = 0.75f;
    private float tempScore = 0.0f;
    public float maxScoreStop = 0.0f;
    //increasing background speed to match difficulty.
    private SkyMove[] skyMove = new SkyMove[4];
    private float skyMoveInterval = 0.0f;
    public float skyMoveMaxSpeed = 0.0f;

    void Start()
    {
        skyMove = FindObjectsOfType<SkyMove>();

        intervalSpawnRate = (spawnRate - maxSpawnRate) / maxScoreStop;
        skyMoveInterval = skyMoveMaxSpeed / maxScoreStop;
    }

	void Update()
    {
        if (!PlayerController.dead && !MissionHandler.mission.missionWin)
        {
            if (tempScore < Score.score && spawnRate > maxSpawnRate)
            {
                tempScore++;
                spawnRate -= intervalSpawnRate;

                foreach (SkyMove x in skyMove)
                {
                    x.speed -= skyMoveInterval;
                }

                if (spawnRate < maxSpawnRate)
                {
                    spawnRate = maxSpawnRate;
                }
            }

            if (enemySpawnPoint == null)
            {
                return;
            }
        
            Vector3 enemyPos;
            enemyPos = new Vector3(
                enemySpawnPoint.position.x,
                Random.Range(enemyMaxHeight.position.y, enemyMinHeight.position.y),
                hotAirBallon.transform.position.z
            );

            Random.InitState(System.Environment.TickCount);

            if (Time.time > nextSpawn && hotAirBallonCount != numBeforeBlimpSpawn)
            {
                int ranNum = 0;
                ranNum = Random.Range(minScoreBallonRange, maxScoreBallonRange);

                if (ranNum == 5 && hotAirBallonTotal > 5)
                {
                    Instantiate(hotAirBallonPlusScore, enemyPos, hotAirBallonPlusScore.transform.rotation);
                }
                else
                {
                    Instantiate(hotAirBallon, enemyPos, hotAirBallon.transform.rotation);
                }

                nextSpawn = Time.time + spawnRate;
                hotAirBallonCount++;
                hotAirBallonTotal++;
            }

            if (Time.time > nextSpawn && hotAirBallonCount == numBeforeBlimpSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                hotAirBallonCount = 0;
                Instantiate(blimp, enemyPos, blimp.transform.rotation);
            }
        }

        //Disable spawning enemies when player dies or mission is won.
        else
        {
            GetComponent<SpawnController>().enabled = false;
        }
    }
}
