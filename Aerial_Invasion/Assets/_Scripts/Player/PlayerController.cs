using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameObject canvasActiveButtons;
    public GameObject canvasDeathButtons;

    public GameObject shot;
    public Transform shotSpawn;
    
    private Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 moveVelocity;
    public float maxSpeed = 0.0f;
    public float forwardspeed = 0.0f;

    static public bool moveButton = false;
    static public bool shootButton = false;
    static public bool shootWait = false;
    private float topOfScreen = 9.0f;
    private float maxRange = 10.0f;

    public float fireSpeed = 0.0f;
    private float nextShot = 0.0f;

    static public bool canButtonMove = true;

    static public bool dead = false;
    static public bool deadGround = false;
    static public float deathCD = 0.0f;

    private AudioSource myAudio;

    void Awake()
    {
        ResetAfterDeath();
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    void Update()
    {       
        if (deadGround)
        {
            deathCD -= Time.deltaTime;
        }

        if (!dead && !MissionHandler.mission.missionWin)
        {
            if (Time.time > nextShot)
            {
                shootWait = false;
                MissleCDFiller.missleRdy = true;

                if (shootButton && !shootWait)
                {
                    //play shooting audio.
                    myAudio.Play();

                    shootButton = false;
                    shootWait = true;
                    nextShot = Time.time + fireSpeed;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    MissleCDFiller.missleCD = true;
                    MissleCDFiller.missleRdy = false;
                }
            }
        }
    }

	void FixedUpdate()
    {
        velocity += gravity * Time.deltaTime;

        velocity.x = forwardspeed;

        if (moveButton && !MissionHandler.mission.missionWin)
        {
            moveButton = false;
            if (velocity.y < 0.0f)
            {
                velocity.y = 0.0f;
            }
            velocity += moveVelocity;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity * Time.deltaTime;

        //Clamps player to top of the screen
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -10.0f, maxRange), transform.position.z);

        if (transform.position.y == maxRange)
        {
            velocity.y = 0.0f;
        }

        if (transform.position.y >= topOfScreen)
        {
            canButtonMove = false;
        }

        if (transform.position.y <= topOfScreen)
        {
            canButtonMove = true;
        }

        if (dead)
        {
            float angle = Mathf.Lerp(0, -90, -velocity.y / maxSpeed);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        if (MissionHandler.mission.missionWin)
        {
            gravity = new Vector3(0.0f, 0.0f, 0.0f);
            velocity.y = 0.0f;
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {   
        velocity.y = 0.0f;

        //Ignore Collision with Enmey after colliding with an Enemy
        Physics2D.IgnoreLayerCollision(0, 10, true);

        //Stop background and Ground from moving.
        SkyMove[] skyMove = FindObjectsOfType<SkyMove>();
        foreach (SkyMove x in skyMove)
        {
            x.speed = 0.0f;
        }

        canvasActiveButtons.SetActive(false);
        canvasDeathButtons.SetActive(true);

        dead = true;

        if (other.gameObject.CompareTag("Ground"))
        {
            //Disable own sprite renderer
            GetComponent<SpriteRenderer>().enabled = false;

            //Disables all childern sprite reneders.
            Component[] rend = GetComponentsInChildren<SpriteRenderer>();

            foreach (Component x in rend)
            {
                x.GetComponent<SpriteRenderer>().enabled = false;
            }

            //Stop moving forward
            forwardspeed = 0.0f;
            
            deadGround = true;
        }
    }

    void ResetAfterDeath()
    {
        dead = false;
        deadGround = false;
        deathCD = 4.0f;
        Physics2D.IgnoreLayerCollision(0, 10, false);
        MissleCDFiller.missleRdy = true;
    }
}
