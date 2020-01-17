using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinValueUI : MonoBehaviour {

    private Image[] childImage;

    public Sprite[] nums = new Sprite[10];

    void Start()
    {
        childImage = GetComponentsInChildren<Image>();
        foreach (Image x in childImage)
        {
            if (x.CompareTag("CoinPos"))
            {
                x.GetComponent<Image>().enabled = false;
            }
        }

        if (GameControl.control.coins == 0)
        {
            childImage[1].enabled = true;
            childImage[1].sprite = nums[0];
        }

        else
        {
            DisplayCoin(GameControl.control.coins);
        }
    }

    void Update()
    {
        if (ButtonHighlight.coinUsed)
        {
            DisplayCoin(GameControl.control.coins);
        }
    }

    public void DisplayCoin(int value)
    {
        childImage = GetComponentsInChildren<Image>();

        bool[] used = new bool[6];

        if (value == 0)
        {
            childImage[1].enabled = true;
            childImage[2].enabled = false;
            childImage[3].enabled = false;
            childImage[4].enabled = false;
            childImage[5].enabled = false;
            childImage[1].sprite = nums[0];
        }

        while (value > 0)
        {
            int digit = value % 10;

            if (value <= 9)
            {
                childImage[1].enabled = true;
                childImage[1].sprite = nums[digit];
                used[1] = true;
            }

            if (value > 9 && value <= 99)
            {
                childImage[2].enabled = true;
                childImage[2].sprite = nums[digit];
                used[2] = true;
            }
            else if (value <= 9 && !used[2])
            {
                childImage[2].enabled = false;
            }

            if (value > 99 && value <= 999)
            {
                childImage[3].enabled = true;
                childImage[3].sprite = nums[digit];
                used[3] = true;
            }
            else if (value <= 99 && !used[3])
            {
                childImage[3].enabled = false;
            }

            if (value > 999 && value <= 9999)
            {   
                childImage[4].enabled = true;
                childImage[4].sprite = nums[digit];
                used[4] = true;
            }
            else if (value <= 999 && !used[4])
            {
                childImage[4].enabled = false;
            }

            if (value > 9999 && value <= 99999)
            {   
                childImage[5].enabled = true;
                childImage[5].sprite = nums[digit];
                used[5] = true;
            }
            else if (value <= 9999 && !used[5])
            {
                childImage[5].enabled = false;
            }

            value /= 10;
        }
    }
}
