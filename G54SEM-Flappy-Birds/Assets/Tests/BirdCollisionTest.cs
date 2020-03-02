using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BirdCollisionTest
{
    GameObject bird;
    GameObject gameManager;

    private void Setup()
    {
        bird = new GameObject();
        bird.AddComponent<CapsuleCollider2D>();
        bird.AddComponent<BirdCollisions>();

        gameManager = new GameObject();
        gameManager.AddComponent<GameManager>();
        gameManager.GetComponent<GameManager>().Awake();
    }

    [Test]
    public void BirdCollisionWithCeilingTest()
    {

        Setup();
        
        GameObject ceiling = new GameObject();
        ceiling.AddComponent<BoxCollider2D>();

        //create the ceiling as same as the ceiling object in the game
        ceiling.transform.position = new Vector3(0f, 4f, 0f);
        ceiling.transform.localScale = new Vector3(1.75f, 0.492f, 1f); 

        bird.transform.position = ceiling.transform.position;
        

        if (bird.transform.position.y == ceiling.transform.position.y)
        {
            if (bird.GetComponent<BirdCollisions>())
            {
                Debug.Log("no bird collision script");
            }

            bird.GetComponent<BirdCollisions>().CheckIfScoreBox(bird.tag);

            if (!GameManager.gameInstance.IsGameOver())
            {
                Debug.Log("bird did not collide the ceiling!");
            }
        }
        else
        {
            Debug.Log("bird pos = " + bird.transform.position.y);
        }
        cleanup(gameManager);
    }

    [Test]
    public void BirdCollisionWithGroundTest()
    {
        Setup(); 

        GameObject ground = new GameObject();
        ground.AddComponent<BoxCollider2D>();

        //create the ground as same as the ground object in the game
        ground.transform.position = new Vector3(0f, -3.2f, 0f);
        ground.transform.localScale = new Vector3(1.75f, 1.85f, 1f);

        bird.transform.position = ground.transform.position;

        if (bird.transform.position.y == ground.transform.position.y)
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

            if (!GameManager.gameInstance.IsGameOver())
            {
                Debug.Log("bird did not collide the ground!");
            }

        }
        else
        {
            Debug.Log("bird pos = " + bird.transform.position.y);
        }

        cleanup(gameManager);
    }

    private void cleanup(GameObject gameObject)
    {
        UnityEngine.Object.DestroyImmediate(gameObject);
    }
}
