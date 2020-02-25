using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollision : MonoBehaviour {

	private GameManager GameController;

	void Start () {
        // initialisation
		GameObject Object = GameObject.FindWithTag("GameController");
		GameController = Object.GetComponent<GameManager>();
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
