using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFocusCam : MonoBehaviour {

    public GameObject BackGroundImage;

	void Awake() 
    {
        BackGroundImage.GetComponent<RectTransform>().anchoredPosition = new Vector3 (GameControl.control.missionModeBackground, 0.0f, 0.0f);
        GameControl.control.missionModeBackground = 0.0f;
	}

    void Update()
    {
        GameControl.control.missionModeBackground = BackGroundImage.GetComponent<RectTransform>().anchoredPosition.x;
    }
}
