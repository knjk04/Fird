using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class isReady : MonoBehaviour {

    // ensure these are all assigned in the inspector in Unity
    public GameObject Score;
    public Rigidbody2D birdRB;
    public AudioSource audio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        { 
            // create scene and show score
            gameObject.SetActive(false);
            Score.SetActive(true);
            // introduce gravity and allow bird to fall
            birdRB.gravityScale = 1f;

            // play background audio
            audio.Play();
            
           
        }  

    }
}
