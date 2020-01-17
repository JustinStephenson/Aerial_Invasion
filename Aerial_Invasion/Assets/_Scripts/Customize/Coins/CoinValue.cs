using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinValue : MonoBehaviour {

    private int tempScore = 0;
    private int tempCount = 0;
    private int tempCoins = 0;

    private Animator coinAnim;

    private bool addCoins = true;

    public GameObject[] nums = new GameObject[10];
    public Transform[] coinPos = new Transform[5];

    private GameObject numClone1;
    private GameObject numClone10;
    private GameObject numClone100;
    private GameObject numClone1000;
    private GameObject numClone10000;

    private AudioSource myAudio;

	void Start()
    {
        coinAnim = GetComponentInChildren<Animator>();
        myAudio = GetComponent<AudioSource>();

        if (GameControl.control.coins == 0)
        {
            numClone1 = (GameObject)Instantiate(nums[0], coinPos[0].position, coinPos[0].rotation);
            numClone1.transform.parent = gameObject.transform;
        }
        else
        {
            DisplayCoin(GameControl.control.coins);
        }
	}

    void Update()
    {
        if (GameOverScreen.gameOverMsgRdy && !MissionHandler.mission.missionModeEnable)
        {
            if (addCoins)
            {
                tempCoins = GameControl.control.coins;
                int scoreAdd = 0;
                scoreAdd = Score.score / 5;
                GameControl.control.coins+= scoreAdd;
                addCoins = false;
            }

            if (ScoreEnd.scorelerp > tempCount)
            {
                tempCount = ScoreEnd.scorelerp;
                tempScore++;
            }

            if (tempScore == 5)
            {
                tempCoins++;
                DisplayCoin(tempCoins);
                myAudio.Play();
                coinAnim.SetBool("Turn", true);
                tempScore = 0;
               // coinAnim.SetBool("Turn", false);
            }
        }
    }

    void DisplayCoin(int value)
    {
        bool[] used = new bool[5];

        if (value == 0)
        {
            Destroy(numClone1);
            numClone1 = (GameObject)Instantiate(nums[0], coinPos[0].position, coinPos[0].rotation);
            numClone1.transform.parent = gameObject.transform;
        }

        while (value > 0)
        {
            int digit = value % 10;

            if (value <= 9)
            {
                Destroy(numClone1);
                numClone1 = (GameObject)Instantiate(nums[digit], coinPos[0].position, coinPos[0].rotation);
                numClone1.transform.parent = gameObject.transform;
                used[0] = true;
            }

            if (value > 9 && value <= 99)
            {
                Destroy(numClone10);
                numClone10 = (GameObject)Instantiate(nums[digit], coinPos[1].position, coinPos[1].rotation);
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
                numClone100 = (GameObject)Instantiate(nums[digit], coinPos[2].position, coinPos[2].rotation);
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
                numClone1000 = (GameObject)Instantiate(nums[digit], coinPos[3].position, coinPos[3].rotation);
                numClone1000.transform.parent = gameObject.transform;
                used[3] = true;
            }
            else if (value <= 999 && !used[3])
            {
                Destroy(numClone1000);
            }

            if (value > 9999 && value <= 99999)
            {   
                Destroy(numClone10000);
                numClone10000 = (GameObject)Instantiate(nums[digit], coinPos[4].position, coinPos[4].rotation);
                numClone10000.transform.parent = gameObject.transform;
                used[4] = true;
            }
            else if (value <= 9999 && !used[4])
            {
                Destroy(numClone10000);
            }

            value /= 10;
    }
}
}
