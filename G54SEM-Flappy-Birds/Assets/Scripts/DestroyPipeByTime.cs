using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPipeByTime : MonoBehaviour {

    public GameManager GameController;
    
	// Use this for initialization
	void Start () {
        
        // if (GameController.IsGameOver())
        if (GameManager.GameInstance.IsGameOver())
        {
            //Debug.Log("Die");
            //Destroy(gameObject);
        }
        else
        {
            // destroys pipes after 8 seconds
            Destroy(gameObject, 8);
        }
	}

    // Update is called once per frame
    void Update()
    {
        // if (GameController.IsGameOver())
        if (GameManager.GameInstance.IsGameOver())
        {
            Debug.Log("Are you dead yet?");
            Destroy(gameObject);
        }
        else
        {
            //Debug.Log("Game is not over");
        }
    }
}
