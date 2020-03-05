using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class GameManagerTest
{
    GameObject gameManagerObject;
    GameManager gameManager;

    public void Setup()
    {
        gameManagerObject = new GameObject();
        gameManagerObject.AddComponent<GameManager>();
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    [Test]
    public void BackgroundAudioPlaysOnStartTest()
    {
        Setup();
        // Add the background audio
        AudioClip backgroundAudioClip = Resources.Load("Audio/background-audio") as AudioClip;
        AudioSource audioSource = gameManagerObject.AddComponent<AudioSource>();
        gameManager.SetAudioSource(audioSource);
        audioSource.clip = backgroundAudioClip;
 
        gameManager.PlayBackgroundAudioOnGameStart();
        Assert.IsTrue(gameManager.GetBackgroundAudioSource().isPlaying);
    }

    [Test]
    public void HighScoreUpdatedTest()
    {
        Setup();
        gameManager.AddScore();
        Assert.IsTrue(gameManager.SetHighScore());
    }
}
