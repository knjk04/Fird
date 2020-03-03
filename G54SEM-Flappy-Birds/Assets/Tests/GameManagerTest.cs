using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class GameManagerTest
{
    [Test]
    public void BackgroundAudioPlaysOnStartTest() {
        // Use the Assert class to test conditions.
        GameObject gameManagerObject = new GameObject();
        gameManagerObject.AddComponent<GameManager>();
        GameManager gameManager = gameManagerObject.GetComponent<GameManager>();

        // Add the background audio
        AudioClip backgroundAudioClip = Resources.Load("Audio/background-audio") as AudioClip;
        AudioSource audioSource = gameManagerObject.AddComponent<AudioSource>();
        gameManager.SetAudioSource(audioSource);
        audioSource.clip = backgroundAudioClip;
 
        gameManager.PlayBackgroundAudioOnGameStart();
        Assert.IsTrue(gameManager.GetBackgroundAudioSource().isPlaying);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator GameManagerTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
