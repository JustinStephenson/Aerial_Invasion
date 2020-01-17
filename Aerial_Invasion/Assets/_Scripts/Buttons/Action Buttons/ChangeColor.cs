using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

public Color changeColor;
private Color tempColor;

    void Start()
    {
        tempColor = GetComponent<Image>().color;
    }

    public void ColorChangeDown()
    {
        GetComponent<Image>().color = changeColor;
    }

    public void ColorChangeUp()
    {
        GetComponent<Image>().color = tempColor;
    }
}
