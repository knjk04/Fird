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
            GameController.GameOver();
        }
    }


    //this function should be called when the bird moves through the score box
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "score-box")
        {
        }
    }
}
