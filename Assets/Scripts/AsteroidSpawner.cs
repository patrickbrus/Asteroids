using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// class to spawn asteroids
/// </summary>

public class AsteroidSpawner : MonoBehaviour {

    [SerializeField]
    GameObject prefabAsteroid;

    GameObject[] Asteroids = new GameObject[4];
    

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start () {

        float posZ = -Camera.main.transform.position.z;

        Asteroids[0] = Instantiate<GameObject>(prefabAsteroid, new Vector3(0, ScreenUtils.ScreenTop, posZ), Quaternion.identity);
        Asteroids[1] = Instantiate<GameObject>(prefabAsteroid, new Vector3(0, ScreenUtils.ScreenBottom, posZ), Quaternion.identity);
        Asteroids[2] = Instantiate<GameObject>(prefabAsteroid, new Vector3(ScreenUtils.ScreenLeft, 0, posZ), Quaternion.identity);
        Asteroids[3] = Instantiate<GameObject>(prefabAsteroid, new Vector3(ScreenUtils.ScreenRight, 0, posZ), Quaternion.identity);

        Asteroids[0].GetComponent<Asteroid>().Initialize(Direction.Up, new Vector3(0, ScreenUtils.ScreenTop, posZ));
        Asteroids[1].GetComponent<Asteroid>().Initialize(Direction.Down, new Vector3(0, ScreenUtils.ScreenBottom, posZ));
        Asteroids[2].GetComponent<Asteroid>().Initialize(Direction.Left, new Vector3(ScreenUtils.ScreenLeft, 0, posZ));
        Asteroids[3].GetComponent<Asteroid>().Initialize(Direction.Right, new Vector3(ScreenUtils.ScreenRight, 0, posZ));
    }

   
}
