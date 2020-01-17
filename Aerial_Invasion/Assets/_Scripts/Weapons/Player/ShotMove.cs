using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour {

    public float moveSpeed = 0.0f;
    private Vector3 explosionPos;
    private Rigidbody2D rb;
    private ObjectHolder obHolder = null;

    public static bool enemyExplosion = false;

	void Start () 
    {
        obHolder = FindObjectOfType<ObjectHolder>();
		rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * moveSpeed;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyExplosion = true;
            explosionPos = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            Instantiate(obHolder.explosion, explosionPos, transform.rotation);
        }
    }
}
