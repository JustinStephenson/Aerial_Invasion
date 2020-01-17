using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CustomizeFocus : MonoBehaviour {

    public GameObject BackGroundImage;
    public GameObject ButtonHandler;

	void Start()
    {
        ButtonHighlight[] bh = ButtonHandler.GetComponentsInChildren<ButtonHighlight>();

        for (int i = 0; i < GameControl.control.skin.Length; i++)
        {
            if (GameControl.control.skin[i] == true)
            {
                for (int x = 0; x < bh.Length; x++)
                {
                    if (bh[x].skinNum == i)
                    {
                        RectTransform myTrans = BackGroundImage.GetComponent<RectTransform>();
                        switch (i)
                        {
                            case 0:
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                                myTrans.anchoredPosition = new Vector3 (0.0f, transform.position.y, transform.position.z);
                                break;
                            case 6:
                            case 7:
                            case 8:
                                myTrans.anchoredPosition = new Vector3 (-112.5f, transform.position.y, transform.position.z);
                                break;
                            case 9:
                            case 10:
                            case 11:
                                myTrans.anchoredPosition = new Vector3 (-322.5f, transform.position.y, transform.position.z);
                                break;
                            case 12:
                            case 13:
                            case 14:
                                myTrans.anchoredPosition = new Vector3 (-532.5f, transform.position.y, transform.position.z);
                                break;
                            case 15:
                            case 16:
                            case 17:
                                myTrans.anchoredPosition = new Vector3 (-742.5f, transform.position.y, transform.position.z);
                                break;
                            case 18:
                            case 19:
                            case 20:
                                myTrans.anchoredPosition = new Vector3 (-952.5f, transform.position.y, transform.position.z);
                                break;
                            case 21:
                            case 22:
                            case 23:
                                myTrans.anchoredPosition = new Vector3 (-1162.5f, transform.position.y, transform.position.z);
                                break;
                            case 24:
                            case 25:
                            case 26:
                                myTrans.anchoredPosition = new Vector3 (-1372.5f, transform.position.y, transform.position.z);
                                break;
                            case 27:
                            case 28:
                            case 29:
                                myTrans.anchoredPosition = new Vector3 (-1582.5f, transform.position.y, transform.position.z);
                                break;
                            case 30:
                            case 31:
                            case 32:
                            case 33:
                            case 34:
                            case 35:
                                myTrans.anchoredPosition = new Vector3 (-1681.0f, transform.position.y, transform.position.z);
                                break;
                        }
                    }
                }
            }
        }
	}
}
