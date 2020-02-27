using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
	// ensure these are set in the inspector
	public Rigidbody2D rigidBody2D;
	//public float speed;
    //public float birdVerticalVelocity;

    private bool birdTiltedUpwards;
    private float birdVerticalPosition;

    //public GameManager GameController;

    private Vector3 birdTransform;
    //private Quaternion BirdRotation;

    //private float rotationSpeed = 1f;

    public void Start() 
	{
        birdTiltedUpwards = false;
        birdTransform = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {

        float vertical = Input.GetAxis("Horizontal");

        if (!GameManager.gameInstance.IsGameOver())
        {
            // move bird up when user presses
            if (Input.GetButton("Fire1"))
            {
				Debug.Log("I believe I can fly");
                
                rigidBody2D.AddForce(new Vector3(0f, 0.6f, 0f), ForceMode2D.Impulse);

				birdVerticalPosition = rigidBody2D.position.y;

                // if bird is falling, change direction
                if (!birdTiltedUpwards)
                {
                    // transform.eulerAngles = Vector3.forward * 25;
                    birdTiltedUpwards = true;
                }
            }
			else
			{
                if (rigidBody2D.position.y < birdVerticalPosition)
                {
                    // transform.eulerAngles = Vector3.forward * -85;
                    birdTiltedUpwards = false;
                }
            }
        }
    }

    public void ResetBird()
    {
        gameObject.transform.position = birdTransform;
        // transform.rotation = Quaternion.identity;
        
    }


}
