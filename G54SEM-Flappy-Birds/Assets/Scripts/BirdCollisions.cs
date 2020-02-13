using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdCollisions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Currently reloads scene
        // TODO: later update to move to a Game Over panel
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
