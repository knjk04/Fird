using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_movement : MonoBehaviour
{
	Rigidbody rb;
	float speed = 60;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		float moveVertical = Input.GetAxis("Vertical");

		//Physics.gravity =  new Vector3(0, -100f, 0);
		Vector3 movement = new Vector3(0.0f, moveVertical, 0.0f);


		// rb.AddForce(movement);
		rb.velocity = speed * movement;
		rb.AddForce(Physics.gravity * 30f, ForceMode.Acceleration);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
