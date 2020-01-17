using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MissleCDFiller : MonoBehaviour {

    public Image missleFill;
    public static bool missleCD = false;
    public static bool missleRdy = true;
    private float missleTimeAmount = 0.0f;

    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

	void Update()
    {
        if (missleCD)
        {
            missleFill.fillAmount = 0;
            missleTimeAmount = 0.0f;
            missleCD = false;
        }

        if (missleFill.fillAmount < 1)
        {
            missleTimeAmount += Time.deltaTime / player.fireSpeed;
            missleFill.fillAmount = missleTimeAmount;
        }
    }
}
