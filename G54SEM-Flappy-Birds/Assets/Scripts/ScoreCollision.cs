using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollision : MonoBehaviour {

	public GameManager GameController;

	void Start () {
        // initialisation
		GameObject Object = GameObject.FindWithTag("GameController");
		GameController = Object.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // function to add score once bird passes through gap in pipes
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			if (GameController == null) {
				Debug.Log("Game controller is null");
			} 
			else 
			{
				GameController.AddScore();
			}
		}
	}
}
