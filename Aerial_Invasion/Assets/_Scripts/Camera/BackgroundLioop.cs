using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLioop : MonoBehaviour {

    private int numBGPanels = 4;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Background") || other.CompareTag("Ground"))
        {
            float otherWidth = ((BoxCollider2D)other).size.x * other.transform.localScale.x;
            Vector3 pos = other.transform.position;
            pos.x += otherWidth * numBGPanels - 0.05f;
            other.transform.position = pos;
        }

        if (other.CompareTag("Enemy") || other.CompareTag("Explosion"))
        {
            Destroy(other.gameObject);
        }
    }
}
