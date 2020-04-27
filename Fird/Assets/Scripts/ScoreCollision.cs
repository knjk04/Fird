using UnityEngine;

// Detects whether there is a collision between the bird and the score box
public class ScoreCollision : MonoBehaviour
{
    /// <summary>
    /// Function to add score once bird passes through gap in pipes.
    /// </summary>
    /// <param name="other">The collider2D object of the object that has been collided into.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        // Check if collided with player
        if (other.gameObject.tag == "Player")
        {
            if (GameManager.gameInstance == null)
            {
                Debug.LogError("Game controller is null");
            }
            else
            {
                // Incerments score as player passed through score-box.
                GameManager.gameInstance.UpdateScore();
            }
        }
    }
}
