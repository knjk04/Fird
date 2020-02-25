using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdCollisions : MonoBehaviour {

    public GameManager GameController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO: later update to move to a Game Over panel
        if (collision.gameObject.tag != "score-box")
        {
            Debug.Log("Collision so end the game");
            GameController.EndGame();
        }
    }
}
