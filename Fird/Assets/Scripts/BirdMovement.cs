using UnityEngine;

public class BirdMovement : MonoBehaviour
{
	// ensure these are set in the inspector

	public Rigidbody2D rigidBody2D;
    public AudioSource flap;
    private Vector3 birdTransform;
    private bool mousePressed = false;
    private bool birdTiltedUpwards;

    public void Start() 
	{
        // Initialise bird direction boolean at start of game
        birdTiltedUpwards = false;
        // Initialisation of flat vector for position reset
        birdTransform = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (!GameManager.gameInstance.IsGameOver())
        {
            // Move bird up when user presses right mouse button
            // Only executes once on each button press
            if (Input.GetButton("Fire1") && !mousePressed)
            {
                mousePressed = true;

                MoveOnInput(rigidBody2D); 

                flap.Play();

                // If bird is falling, change direction
                if (!birdTiltedUpwards)
                {
                    // transform.eulerAngles = Vector3.forward * 25;
                    birdTiltedUpwards = true;
                }
            }
			else
			{
                // Resets pressed to false on button up
                if (!Input.GetButton("Fire1"))
                {
                    mousePressed = false;
                }
            }
            
        }
    }

    /// <summary>
    /// Resets bird to flat ready for start.
    /// </summary>
    public void ResetBird()
    {
        gameObject.transform.position = birdTransform;
    }


    /// <summary>
    /// Handles input from user and moves bird accordingly.
    /// </summary>
    /// <param name="birdRigidBody">Bird sprite rigidbody.</param>
    public void MoveOnInput(Rigidbody2D birdRigidBody)
    {
        float verticalSpeedAdd = 4.0f;
        Vector3 v = birdRigidBody.velocity;
        birdRigidBody.AddForce(-v, ForceMode2D.Impulse);
        birdRigidBody.AddForce(new Vector3(0f, verticalSpeedAdd, 0f), ForceMode2D.Impulse);

        if (flap != null)
        {
            flap.Play();
        }      
    }
}