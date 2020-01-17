using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlimpShotMove : MonoBehaviour {

    public float moveSpeed = 0.0f;
    private Rigidbody2D rb;

    void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {   
//        if (other.gameObject.CompareTag("Player"))
//        {
            Destroy(gameObject);
 //       }
    }
}
