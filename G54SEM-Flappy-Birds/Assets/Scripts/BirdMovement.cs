using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
	// ensure these are set in the inspector
	public Rigidbody2D RigidBody2D;
	public float Speed;

	public void Start() 
	{

	}

	private void FixedUpdate()
	{
        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Fire1"))
        {
            RigidBody2D.velocity += new Vector2(0f, 0.75f);
        }
	}
}
