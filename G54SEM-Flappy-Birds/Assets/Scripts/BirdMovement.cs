using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
	// ensure these are set in the inspector

	public Rigidbody2D rigidBody2D;
    public AudioSource flap;

    private bool birdTiltedUpwards;
    private float birdVerticalPosition;

    private Vector3 birdTransform;

    public void Start() 
	{
        birdTiltedUpwards = false;
        birdTransform = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (!GameManager.gameInstance.IsGameOver())
        {
            // move bird up when user presses
            if (Input.GetButton("Fire1"))
            {
                MoveOnInput(rigidBody2D );
            }
        }
    }

    public void ResetBird()
    {
        gameObject.transform.position = birdTransform;
    }

    public void MoveOnInput(Rigidbody2D birdRigidBody)
    {
        birdRigidBody.AddForce(new Vector3(0f, 0.6f, 0f), ForceMode2D.Impulse);

        birdVerticalPosition = birdRigidBody.position.y;

        if (flap != null)
        {
            flap.Play();
        }      
    }
}