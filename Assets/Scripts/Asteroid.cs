using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// method to instantiate a asteroid with a random Impuls
/// </summary>
public class Asteroid : MonoBehaviour
{

    [SerializeField]
    Sprite[] sprite = new Sprite[3];

   

    const float minImpuls = 1.5f;
    const float maxImpuls = 2.5f;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {

        SpriteRenderer actualSprite = GetComponent<SpriteRenderer>();

        actualSprite.sprite = sprite[Random.Range(0, 2)];

       
    }

    /// <summary>
    /// method to initialize an asteriod and let him move into the direction of the enum input parameter
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="startingPos"></param>
    public void Initialize(Direction direction, Vector3 startingPos)
    {
        // code to let the asteroid spwan at startingPos
        transform.position = startingPos;
        
        float angle = Random.Range(0, 30 * Mathf.Deg2Rad);

        if (direction == Direction.Up)
        {
            angle += 75 * Mathf.Deg2Rad;
        }
        else if(direction == Direction.Left)
        {
            angle += 165 * Mathf.Deg2Rad;
        }
        else if(direction == Direction.Down)
        {
            angle += 255 * Mathf.Deg2Rad;
        }

        this.startMoving(angle);
        
    }

    /// <summary>
    /// Method to let asteroids move 
    /// </summary>
    /// <param name="angle"></param>
    public void startMoving(float angle)
    {
        Vector2 movingDir = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));

        float magnitude = Random.Range(minImpuls, maxImpuls);
        GetComponent<Rigidbody2D>().AddForce(
            movingDir * magnitude,
            ForceMode2D.Impulse);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // play sound everytime an asteroid got hit by a bullet
        AudioManager.Play(AudioClipName.AsteroidHit);

        if(collision.gameObject.tag == "Bullet" && this.transform.localScale.x >= 0.5)
        {
            // store actual scale of asteroid in a new variable and scale the newScale to resize the asteroid
            Vector3 newScale = this.transform.localScale;
            newScale.x /= 2;
            newScale.y /= 2;

            // store the newScale into the actual scale of the asteroid
            this.transform.localScale = newScale;

            // now cut the radius of the asteroid to make sure screen wrapping workes fine
            this.GetComponent<CircleCollider2D>().radius /= 2;

            // instantiate the new smaller asteroids
            GameObject asteroid1 = Instantiate<GameObject>(this.gameObject);
            GameObject asteroid2 = Instantiate<GameObject>(this.gameObject);

            asteroid1.GetComponent<Asteroid>().startMoving(Random.Range(0,2*Mathf.PI));
            asteroid2.GetComponent<Asteroid>().startMoving(Random.Range(0, 2 * Mathf.PI));

            Destroy(this.gameObject);
        }
        else if(this.transform.localScale.x < 0.5)
        {
            Destroy(this.gameObject);
        }
    }
}


