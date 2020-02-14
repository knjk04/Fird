using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
	// ensure these are set in the inspector
	public Rigidbody2D RigidBody2D;
	public float Speed;
    public float BirdVerticalVelocity;

    public bool BirdTiltedUpwards;

	public void Start() 
	{
        BirdTiltedUpwards = false;
	}

    private void FixedUpdate()
	{
        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Fire1"))
        {
            RigidBody2D.velocity += new Vector2(0f, BirdVerticalVelocity);

            if (!BirdTiltedUpwards)
            {
                Debug.Log("Tilt because birdTiltedUpwards = " + BirdTiltedUpwards);
                transform.eulerAngles = Vector3.forward * 25;
                BirdTiltedUpwards = true;
            }
        }
        else
        {
            transform.eulerAngles = Vector3.forward * -85;
            BirdTiltedUpwards = false;
        }
	}

    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Fire1"))
        {
            RigidBody2D.velocity += new Vector2(0f, BirdVerticalVelocity);

            if (!BirdTiltedUpwards)
            {
                Debug.Log("Tilt because birdTiltedUpwards = " + BirdTiltedUpwards);
                transform.eulerAngles = Vector3.forward * 25;
                BirdTiltedUpwards = true;
            }
        }
        else
        {
            transform.eulerAngles = Vector3.forward * -85;
            BirdTiltedUpwards = false;
        }
        */
        


    }
}
