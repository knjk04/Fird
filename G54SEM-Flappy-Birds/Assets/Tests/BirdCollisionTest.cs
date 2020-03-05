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

    /// <summary>
    /// Tests logic of collision of bird with ceiling.
    /// </summary>
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
            bird.GetComponent<BirdCollisions>().CheckIfNotScoreBox(bird.tag);

            Assert.IsTrue(GameManager.gameInstance.IsGameOver());
        }
        else
        {
            Debug.Log("bird pos = " + bird.transform.position.y);
        }
        Cleanup(gameManager);
    }

    /// <summary>
    /// Tests logic of bird colliding with ground.
    /// </summary>
    [Test]
    public void BirdCollisionWithGroundTest()
    {
        Setup(); 

        GameObject ground = new GameObject();
        ground.AddComponent<BoxCollider2D>();

        // Create the ground as same as the ground object in the game
        ground.transform.position = new Vector3(0f, -3.2f, 0f);
        ground.transform.localScale = new Vector3(1.75f, 1.85f, 1f);

        bird.transform.position = ground.transform.position;

        if (bird.transform.position.y == ground.transform.position.y)
        {
            bird.GetComponent<BirdCollisions>().CheckIfNotScoreBox(bird.tag);

            Assert.IsTrue(GameManager.gameInstance.IsGameOver());
        }
        else
        {
            Debug.Log("bird pos = " + bird.transform.position.y);
        }

        Cleanup(gameManager);
    }

    /// <summary>
    /// Tests logic of bird colliding with pipes.
    /// </summary>
    [Test]
    public void BirdCollisionWithPipeTest()
    {
        Setup();
        
        GameObject pipe = new GameObject();
        pipe.AddComponent<BoxCollider2D>();

        //create the pipe as same as the pipe object in the game
        pipe.transform.position = new Vector3(-9.2895f, -2.0678f, 0f);
        pipe.transform.localScale = new Vector3(1f, 1f, 1f); 

        bird.transform.position = pipe.transform.position;
        
        if (bird.transform.position.y == pipe.transform.position.y)
        { 
            bird.GetComponent<BirdCollisions>().CheckIfNotScoreBox(bird.tag);

            Assert.IsTrue(GameManager.gameInstance.IsGameOver());
        }
        else
        {
            Debug.Log("bird pos = " + bird.transform.position.y);
        }
        Cleanup(gameManager);
    }

    /// <summary>
    /// Test checks whether score is reset correctly.
    /// </summary>
    [Test]
    public void ScoreResetTest()
    {
        Setup();
        GameManager.gameInstance.AddScore(); // 1
        int scoreEnd = GameManager.gameInstance.GetScore(); // 1

        GameManager.gameInstance.ResetScore();
        scoreEnd = GameManager.gameInstance.GetScore(); // 0

        Assert.AreEqual(scoreEnd, 0);
    }

    private void Cleanup(GameObject gameObject)
    {
        UnityEngine.Object.DestroyImmediate(gameObject);
    }
}
