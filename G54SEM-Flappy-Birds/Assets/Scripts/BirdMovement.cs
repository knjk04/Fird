using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
	// ensure these are set in the inspector
	public Rigidbody2D RigidBody2D;
	public float Speed;
    public float BirdVerticalVelocity;

    private bool BirdTiltedUpwards;
    private float BirdVerticalPosition;

	public void Start() 
	{
        BirdTiltedUpwards = false;
	}

    private void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Fire1")))
        {

            RigidBody2D.velocity += new Vector2(0f, BirdVerticalVelocity);

            BirdVerticalPosition = RigidBody2D.position.y;

            if (!BirdTiltedUpwards)
            {
                transform.eulerAngles = Vector3.forward * 25;
                BirdTiltedUpwards = true;
            }
        }
        else
        {
            if (RigidBody2D.position.y < BirdVerticalPosition)
            {
                transform.eulerAngles = Vector3.forward * -85;
                BirdTiltedUpwards = false;
            }
        }
    }
}
