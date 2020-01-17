using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movespeed = 0.0f;
    public float maxDist = 0.0f;
    public float minDist = 0.0f;

    private bool startMove = true;
    private bool movedDown = false;
    private bool movedUp = false;
    private float myStartPos = 0.0f;

    void Start()
    {
        myStartPos = transform.position.y;
    }

    void Update()
    {
        if (startMove)
        {
            transform.Translate(Vector3.down * movespeed);
        }
                        
        if (transform.position.y <= myStartPos - minDist)
        {
            startMove = false;
            movedUp = false;
            movedDown = true;
        }

        if (transform.position.y >= myStartPos + maxDist)
        {
            startMove = false;
            movedDown = false;
            movedUp = true;
        }

        if (movedDown)
        {
            transform.Translate(-Vector3.down * movespeed);
        }

        if (movedUp)
        {
            transform.Translate(Vector3.down * movespeed);
        }
    }
}
