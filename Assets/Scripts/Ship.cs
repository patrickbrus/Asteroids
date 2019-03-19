using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ship class to declare behaviour of the ship
/// </summary>
public class Ship : MonoBehaviour {

    [SerializeField]
    GameObject prefabBullet;

    [SerializeField]
    HUD hud;

    Rigidbody2D myObject;
    Vector2 thrustDirection = new Vector2(1, 0);

    // Variable for force to move the ship
    const float thrustForce = 11;

    // Variable for rotating the ship
    const float rotateSpeedPerSecond = 120;

    // Timer for livingtime bullets
    Timer timer;
   

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start () {
        myObject = GetComponent<Rigidbody2D>();

        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>

   void Update()
    {
        // check for rotation input
        float rotation = Input.GetAxis("Rotate");
        if (rotation != 0)
        {

            // calculate rotation amount and apply rotation
            float rotationAmount = rotateSpeedPerSecond * Time.deltaTime;
            if (rotation < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match ship rotation
            float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(angle);
            thrustDirection.y = Mathf.Sin(angle);

        }

        // if the left Key was pressed -> fire bullet
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            // initialize bullet on ships's position
            Vector3 posBullet = this.transform.position;

            GameObject Bullet = Instantiate<GameObject>(prefabBullet, posBullet, Quaternion.identity);

            // let bullet move into actual direction of ship
            Bullet.GetComponent<Rigidbody2D>().AddForce(thrustDirection * thrustForce, ForceMode2D.Impulse);

            AudioManager.Play(AudioClipName.PlayerShot);

           
        }
        
        
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") != 0)
        {
            myObject.AddForce(thrustDirection * thrustForce, ForceMode2D.Force);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(this.gameObject);
            hud.StopGameTimer();
            AudioManager.Play(AudioClipName.PlayerDeath);
        }
    }

}
