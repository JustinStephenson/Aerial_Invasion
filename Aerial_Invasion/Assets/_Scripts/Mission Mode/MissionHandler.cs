using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MissionHandler : MonoBehaviour {

    //Scenes.
    private Scene currentScene;
    private string sceneName;

    public static MissionHandler mission;

    public bool missionModeEnable = false;
    public bool missionWin = false;

    public enum missionType
    {
        ballonKill,
        survive,
        blimpKill
    };
    public missionType missionTypes;

    //for ballon mission.
    public int missionBallonsTotal = 0;
    public int ballonKillCount = 0;

    //for survie mission
    public float missionSurviveTime = 0;
    public float surviveTimeRemaining = 1;

    //for blimp mission
    public int missionBlimpTotal = 0;
    public int blimpKillCount = 0;

    //for sounds
    private AudioSource myAudio;
    public AudioClip victoryJingle;
    public bool playOnce = false;

    void Awake()
    {
        if (mission == null)
        {
            DontDestroyOnLoad(gameObject);
            mission = this;
        }
        else if (mission != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == "MainMenu")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (missionModeEnable)
        {
            if (missionTypes == missionType.ballonKill)
            {
                if (PlayerController.dead)
                {
                    ballonKillCount = 0;
                }

                if (ballonKillCount == missionBallonsTotal)
                {
                    Victory();
                }
            }

            if (missionTypes == missionType.survive)
            {
                if (PlayerController.dead)
                {
                    surviveTimeRemaining = 1;
                }

                if (surviveTimeRemaining >= missionSurviveTime)
                {
                    Victory();
                }
            }

            if (missionTypes == missionType.blimpKill)
            {
                if (PlayerController.dead)
                {
                    blimpKillCount = 0;
                }

                if (blimpKillCount == missionBlimpTotal)
                {
                    Victory();
                }
            }
        }
    }

    void Victory()
    {
        missionWin = true;
        if (!playOnce)
        {
            playOnce = true;
            Invoke("Jingle", 0.2f);
        }
    }

    void Jingle()
    {
        myAudio.PlayOneShot(victoryJingle, 1.0f);
    }
}
