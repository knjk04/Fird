using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
	// ensure these are set in the inspector
	public Rigidbody2D RigidBody2D;
    // TODO: need to implement a hardcoded speed or the bird will constantly increase in speed....
	public float Speed;
    public float BirdVerticalVelocity;

    private bool BirdTiltedUpwards;
    private float BirdVerticalPosition;

    public GameManager GameController;

	public void Start() 
	{
        BirdTiltedUpwards = false;
	}

    private void FixedUpdate()
    {
        if (!GameController.IsGameOver())
        {
            // move bird up when user presses
            if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Fire1")))
            {
                RigidBody2D.velocity += new Vector2(0f, BirdVerticalVelocity);

                BirdVerticalPosition = RigidBody2D.position.y;

                // if bird is falling, change direction
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
        else
        {
            //Debug.Log("Bird should not move because the game is over");
        }
    }
}
