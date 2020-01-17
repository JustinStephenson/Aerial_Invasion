using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Audio;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    //Coins.
    public int coins;

    //Score
    public int highScore;

    //Scenes.
    private Scene currentScene;
    private string sceneName;

    //Skins.
    public int skinNum = 0;
    public bool[] skin = new bool[36];
    public int[] buttonUnlocks = new int[36];

    //Missions.
    public int[] missionOn = new int[36];
    public int[] missionsDone = new int[36];
    public float missionModeBackground;
    public int coinToWinMission = 0;

    //Sounds
    public bool musicSound = true;
    public bool sfxSound = true;
    public AudioMixer masterMixer;
    
	void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
	}

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        Load();

        skin[skinNum] = true;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        Save();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == "Customize")
        {
            CustomizeLoad();
        }

        if (sceneName == "MissionMode")
        {
            if (MissionHandler.mission.missionWin)
            {
                for (int i = 0; i < missionsDone.Length; i++)
                {
                    missionsDone[i] = missionsDone[i] + missionOn[i];
                    if (missionsDone[i] > 1)
                    {
                        missionsDone[i] = 1;
                    }
                }
                //possibly make it so you only gain coins when you win the first time.
                coins += coinToWinMission;
                coinToWinMission = 0;

                MissionHandler.mission.missionWin = false;
                MissionHandler.mission.playOnce = false;
            }
            MissionModeLoad();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.coins = coins;
        data.highScore = highScore;
        data.skinNum = skinNum;
        data.buttonUnlocks = buttonUnlocks;
        data.missionsDone = missionsDone;
        data.musicSound = musicSound;
        data.sfxSound = sfxSound;
        data.missionModeBackground = missionModeBackground;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);

            coins = data.coins;
            highScore = data.highScore;
            skinNum = data.skinNum;
            buttonUnlocks = data.buttonUnlocks;
            missionsDone = data.missionsDone;
            musicSound = data.musicSound;
            sfxSound = data.sfxSound;
            missionModeBackground = data.missionModeBackground;
        }
    }

//    public void Delete()
//    {
//        return;
//    }

    public void SoundLoad()
    {
        if (musicSound)
        {
            masterMixer.SetFloat("Music", 0.0f);
        }
        else
        {
            masterMixer.SetFloat("Music", -80.0f);
        }

        if (sfxSound)
        {
            masterMixer.SetFloat("SFX", 0.0f);
        }
        else
        {
            masterMixer.SetFloat("SFX", -80.0f);
        }
    }

    void CustomizeLoad()
    {
        GameObject buttonHandler = GameObject.Find("ButtonHandler");
        ButtonHighlight[] bh = buttonHandler.GetComponentsInChildren<ButtonHighlight>();
        int i = 0;
        foreach (int x in buttonUnlocks)
        {
            if (buttonUnlocks[i] == 1)
            {
                bh[i].unlocked = true;
            }
            i++;
        }
    }

    void MissionModeLoad()
    {
        GameObject buttonHandler = GameObject.Find("ButtonHandler");
        ButtonMission[] bh = buttonHandler.GetComponentsInChildren<ButtonMission>();
        int i = 0;
        foreach (int x in missionsDone)
        {
            if (missionsDone[i] == 1)
            {
                bh[i].missionComplete = true;
            }
            i++;
        }
    }
}

[Serializable]
class PlayerData
{
    public int coins;
    public int highScore; 
    public int skinNum;
    public int[] buttonUnlocks = new int[36];
    public int[] missionsDone = new int[36];
    public bool musicSound;
    public bool sfxSound;
    public float missionModeBackground;
}
