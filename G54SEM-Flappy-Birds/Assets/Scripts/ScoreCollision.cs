using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollision : MonoBehaviour {

	public GameManager GameController;

	// Use this for initialization
	void Start () {
		GameObject Object = GameObject.FindWithTag("GameController");
		GameController = Object.GetComponent<GameManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //this function should be called when the bird moves through the score box
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
