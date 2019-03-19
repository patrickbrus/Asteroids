using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// method that gets called if a gameobject leaves the camera field
/// should let the gameobject appeare on the opposit site of the screen
/// </summary>
public class ScreenWraper : MonoBehaviour
{

    // screen wrapping support
    float colliderRadius;

    // Use this for initialization
    void Start()
    {

        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }



    /// <summary>
    /// Called when the game object becomes invisible to the camera
    /// </summary>
    void OnBecameInvisible()
    {
        Vector2 position = transform.position;


        // check left, right, top, and bottom sides
        if (position.x + colliderRadius < ScreenUtils.ScreenLeft ||
            position.x - colliderRadius > ScreenUtils.ScreenRight)
        {
            position.x *= -1;
        }
        if (position.y - colliderRadius > ScreenUtils.ScreenTop ||
            position.y + colliderRadius < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        //move ship
        transform.position = position;
    }
}
