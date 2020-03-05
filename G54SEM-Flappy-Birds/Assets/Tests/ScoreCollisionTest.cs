using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ScoreCollisionTest
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
    /// Function tests logic when player collides with a scorebox.
    /// </summary>
    [Test]
    public void ScoreCollisionTests() {
        Setup();

        GameObject scoreBox = new GameObject();
        scoreBox.AddComponent<BoxCollider2D>();

        float positionHorizontal = 1.997f;
        float positionVertical = 1.42f;
        float positionDepth = 0.002211373f;
        float localScaleHorizontal = 0.3971875f;
        float localScaleVertical = 1.460156f;
        float localScaleDepth = 1f;

        //create the ScoreBox as same as the ceiling object in the game
        scoreBox.transform.position = new Vector3(positionHorizontal, positionVertical, positionDepth);
        scoreBox.transform.localScale = new Vector3(localScaleHorizontal, localScaleVertical, localScaleDepth);

        bird.transform.position = scoreBox.transform.position + scoreBox.transform.localScale / 2;

        int scoreBeforeCollision = GameManager.gameInstance.GetScore();
        // If bird is higher than the bottom of the box then add 1 to score.
        // Note if bird is higher than the box, it will hit the pipe and
        // the game will end.
        if (bird.transform.position.x > scoreBox.transform.position.x)
        {
            GameManager.gameInstance.AddScore();
            int scoreAfterCollision = GameManager.gameInstance.GetScore();
            Assert.AreEqual(scoreBeforeCollision+1, scoreAfterCollision);
        }
        else
        {
            Debug.LogError("Score not added");
        }   
    }
}
