using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeVelocity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
        //Vector2 physicsVelocity = Vector2.zero;
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        //physicsVelocity.x -= 1;
        
        // apply the updated velocity to the rigid body
        r.velocity = new Vector2(-1.0f,0.0f);
    }
}
