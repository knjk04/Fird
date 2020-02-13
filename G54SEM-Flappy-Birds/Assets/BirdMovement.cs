using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
	// ensure these are set in the inspector
	public Rigidbody2D RigidBody2D;
	public float Speed;

	private void FixedUpdate()
	{
		float MoveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(0.0f, MoveVertical);
		RigidBody2D.velocity = Speed * movement;

		RigidBody2D.AddForce(Vector3.down * 60f * RigidBody2D.mass);
	}
}
