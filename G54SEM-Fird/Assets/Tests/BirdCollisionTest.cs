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

        float positionHorizontal = 0f;
        float positionVertical = 4f;
        float positionDepth = 0f;
        float localScaleHorizontal = 1.75f;
        float localScaleVertical = 0.429f;
        float localScaleDepth = 1f;

        //create the ceiling as same as the ceiling object in the game
        ceiling.transform.position = new Vector3(positionHorizontal, positionVertical, positionDepth);
        ceiling.transform.localScale = new Vector3(localScaleHorizontal, localScaleVertical, localScaleDepth); 

        bird.transform.position = ceiling.transform.position;
        
        if (bird.transform.position.y == ceiling.transform.position.y)
        {
            bird.GetComponent<BirdCollisions>().CheckIfNotScoreBox(bird.tag);

            Assert.IsTrue(GameManager.gameInstance.IsGameOver());
        }
        else
        {
            Debug.LogError("bird pos = " + bird.transform.position.y);
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

        float positionHorizontal = 0f;
        float positionVertical = -3.2f;
        float positionDepth = 0f;
        float localScaleHorizontal = 1.75f;
        float localScaleVertical = 1.85f;
        float localScaleDepth = 1f;

        // Create the ground as same as the ground object in the game
        ground.transform.position = new Vector3(positionHorizontal, positionVertical, positionDepth);
        ground.transform.localScale = new Vector3(localScaleHorizontal, localScaleVertical, localScaleDepth);

        bird.transform.position = ground.transform.position;

        if (bird.transform.position.y == ground.transform.position.y)
        {
            bird.GetComponent<BirdCollisions>().CheckIfNotScoreBox(bird.tag);

            Assert.IsTrue(GameManager.gameInstance.IsGameOver());
        }
        else
        {
            Debug.LogError("bird pos = " + bird.transform.position.y);
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

        float positionHorizontal = -9.2895f;
        float positionVertical = -2.0678f;
        float positionDepth = 0f;
        float localScaleHorizontal = 1f;
        float localScaleVertical = 1f;
        float localScaleDepth = 1f;

        //create the pipe as same as the pipe object in the game
        pipe.transform.position = new Vector3(positionHorizontal, positionVertical, positionDepth);
        pipe.transform.localScale = new Vector3(localScaleHorizontal, localScaleVertical, localScaleDepth);

        bird.transform.position = pipe.transform.position;
        
        if (bird.transform.position.y == pipe.transform.position.y)
        { 
            bird.GetComponent<BirdCollisions>().CheckIfNotScoreBox(bird.tag);

            Assert.IsTrue(GameManager.gameInstance.IsGameOver());
        }
        else
        {
            Debug.LogError("bird pos = " + bird.transform.position.y);
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

    /// <summary>
    /// Destroys object being tested once testing has finished.
    /// </summary>
    /// <param name="gameObject">Game object being tested and subsequently deleted.</param>
    private void Cleanup(GameObject gameObject)
    {
        UnityEngine.Object.DestroyImmediate(gameObject);
    }
}
