using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BirdCollisionTest
{

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator BirdCollisionWithCeilingTest() {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        GameObject bird = new GameObject();
        GameObject ceiling = new GameObject();
        //GameObject ground = new GameObject();
        //ground.AddComponent<>();

        Rigidbody2D bird2D = bird.AddComponent<Rigidbody2D>();

        Vector2 priorVelocity = bird2D.velocity;
        bird.AddComponent<CapsuleCollider2D>();
        bird.AddComponent<BirdMovement>();
        bird.AddComponent<BirdCollisions>();
        ceiling.AddComponent<BoxCollider2D>();
        

        //create the ceiling as same as the ceiling object in the game
        ceiling.transform.position = new Vector3(0f, 4f, 0f);
        ceiling.transform.localScale = new Vector3(1.75f, 0.492f, 1f); 

        // bird.transform.position = new Vector3(0f, 0f, 0f);

        bird.GetComponent<BirdMovement>().MoveOnInput(bird.GetComponent<Rigidbody2D>());

        bird.transform.position = ceiling.transform.position;
        Debug.Log("bird pos = " + bird.transform.position.y);

        GameObject gameManager = new GameObject();
        gameManager.AddComponent<GameManager>();
        gameManager.GetComponent<GameManager>().Awake();

        if (bird.transform.position.y == ceiling.transform.position.y)
        {
            if (bird.GetComponent<BirdCollisions>())
            {
                Debug.Log("no bird collision script");
            }
            else 
            {
                Debug.Log("bird collision script");
            }

            bird.GetComponent<BirdCollisions>().CheckIfScoreBox(bird.tag);

            if (GameManager.gameInstance.IsGameOver())
            {
                Debug.Log("bird collide the ceiling!");
            }
            else
            {
                Debug.Log("bird did not collide the ceiling!");
            }
            
        }
        else
        {
            Debug.Log("bird pos = " + bird.transform.position.y);
        }
        
        
        


        yield return null;
    }
}
