using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdCollisions : MonoBehaviour {

    public GameManager GameController;
    private Animator animator;
    //private bool isDead = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Currently reloads scene
        //TODO: later update to move to a Game Over panel
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //isDead = true;
        //animator.settrigger("die");                        // change current animation clip to die


        // Debug.Log("OnCollisionEnter: not score box");

        // // if (collision.gameObject.tag == "score-box")
        // if (collision.gameObject.CompareTag("score-box"))
        //     {
        //     Debug.Log("Collision");
        //     if (GameController == null)
        //     {
        //         Debug.Log("GameController is null");
        //     }

        //     GameController.AddScore();
        // }

 
    }


    //this function should be called when the bird moves through the score box
    public void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log("not score box");
        // Debug.Log("tag = " + other.gameObject.tag);

        // // if (other.gameObject.tag == "score-box")
        // if (other.gameObject.CompareTag("score-box"))
        //     {
        //     Debug.Log("Log");
        //     if (GameController == null)
        //     {
        //         Debug.Log("GameController is null");
        //     }

        //     GameController.AddScore();
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("not score box");
        // Debug.Log("tag = " + other.gameObject.tag);

        // // if (other.gameObject.tag == "score-box")
        // if (other.gameObject.CompareTag("score-box"))
        //     {
        //     Debug.Log("Log");
        //     if (GameController == null)
        //     {
        //         Debug.Log("GameController is null");
        //     }

        //     GameController.AddScore();
        // }
    }
}
