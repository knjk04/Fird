using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("In OnTriggerExit in PipeCollision");
		if (other.gameObject.tag == "Player") {
			Debug.Log("Collision!");
		}
	}
}
