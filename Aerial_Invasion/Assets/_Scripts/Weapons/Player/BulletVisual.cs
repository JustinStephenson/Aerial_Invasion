using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVisual : MonoBehaviour {

	void Update()
    {
        if (!PlayerController.dead)
        {
            if (MissleCDFiller.missleRdy)
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
	}
}
