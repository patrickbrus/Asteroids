using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// class to let timer for Bullet start and to destroy bullet if death time is reached
/// </summary>
public class Bullet : MonoBehaviour {

    #region Fields
    //variable to initialize timer
    Timer timer;

    // constant to store duration of bullet lifetime
    const float duration = 2;
    #endregion

    // Use this for initialization
    void Start () {
        timer = this.GetComponent<Timer>();
        timer.Duration = duration;
        timer.Run();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(timer.Finished)
        {
            Destroy(this.gameObject);
        }
	}
}
