using UnityEngine;

public class BirdMovement : MonoBehaviour
{
	// ensure these are set in the inspector

	public Rigidbody2D rigidBody2D;
    public AudioSource flap;
    private Vector3 birdTransform;
    public float verticalSpeedAdd = 4.0f;
    private bool pressed = false;
    private bool birdTiltedUpwards;

    // to be removed as not value assigned is never read
    private float birdVerticalPosition;

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
            if (Input.GetButton("Fire1") && !pressed)
            {
                pressed = true;

                // does this need to be put in the MoveOnInput() method?
                // the tests are running different logic otherwise
                Vector3 v = rigidBody2D.velocity;
                rigidBody2D.AddForce(-v, ForceMode2D.Impulse);
                rigidBody2D.AddForce(new Vector3(0f, verticalSpeedAdd, 0f), ForceMode2D.Impulse);

				birdVerticalPosition = rigidBody2D.position.y;

                flap.Play();

                // if bird is falling, change direction
                if (!birdTiltedUpwards)
                {
                    // transform.eulerAngles = Vector3.forward * 25;
                    birdTiltedUpwards = true;
                }
            }
			else
			{
                if (!Input.GetButton("Fire1"))
                {
                    pressed = false;
                }
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