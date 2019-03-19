using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// class to display the time the player plays the game
/// </summary>
public class HUD : MonoBehaviour {

    [SerializeField]
    Text hud;

    float elapsedSeconds = 0;
    bool running;

	// Use this for initialization
	void Start () {
        hud.text = "0";
        running = true;
	}
	
	// Update is called once per frame
	void Update () {
       
        if(running)
        {
            elapsedSeconds += Time.deltaTime;

            hud.text = ((int)elapsedSeconds).ToString();
        }
	}

    public void StopGameTimer()
    {
        running = false;
    }
}
