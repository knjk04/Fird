﻿using UnityEngine;
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

    [Test]
    public void ScoreCollisionTests() {
        Setup();

        GameObject scoreBox = new GameObject();
        scoreBox.AddComponent<BoxCollider2D>();

        //create the ScoreBox as same as the ceiling object in the game
        scoreBox.transform.position = new Vector3(1.997f, 1.42f, 0.002211373f);
        scoreBox.transform.localScale = new Vector3(0.3971875f, 1.460156f, 1f);

        bird.transform.position = scoreBox.transform.position + scoreBox.transform.localScale / 2;

        int scoreBeforeCollision = GameManager.gameInstance.GetScore();
        if (bird.transform.position.x > scoreBox.transform.position.x)
        {
            GameManager.gameInstance.UpdateScore();
            int scoreAfterCollision = GameManager.gameInstance.GetScore();
            Assert.AreEqual(scoreBeforeCollision+1, scoreAfterCollision);
        }
        else
        {
            Debug.Log("Score not added");
        }   
    }
}