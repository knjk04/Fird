using UnityEngine;

public class BirdCollisions : MonoBehaviour 
{
    public AudioSource collisonSoundEffect;
    private bool collisionSoundEffectPlayed = false;

    /// <summary>
    /// Function handles when bird collides with objects.
    /// </summary>
    /// <param name="collision">Object player has collided with.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if player has collided with environment
        if(CheckIfNotScoreBox(collision.gameObject.tag))
        {
            if (!collisionSoundEffectPlayed)
            {
                collisonSoundEffect.Play();
                collisionSoundEffectPlayed = true;
            }
            // Game ends as player has collided with environment
            GameManager.gameInstance.EndGame();
        }
    }

    /// <summary>
    /// Function checks if the object collided with is a score box.
    /// </summary>
    /// <param name="tag">tag (name) of object collided with</param>
    /// <returns>Boolean true if environment game object.</returns>
    public bool CheckIfNotScoreBox(string tag)
    {
        GameManager.gameInstance.SetGameOver();
        return (tag != "score-box");
    }

    /// <summary>
    /// Sets boolean sound state to false (ready for playing when bird next hits an object).
    /// </summary>
    public void ResetCollisionSoundEffectPlayed()
    {
        collisionSoundEffectPlayed = false;
    }
}
