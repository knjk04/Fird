using UnityEngine;

// Detects whether there is a collision between the bird and the score box
public class ScoreCollision : MonoBehaviour
{
    // function to add score once bird passes through gap in pipes
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GameManager.gameInstance == null)
            {
                Debug.Log("Game controller is null");
            }
            else
            {
                //Debug.Log("Call add score");
                GameManager.gameInstance.AddScore();
            }
        }
    }
}
