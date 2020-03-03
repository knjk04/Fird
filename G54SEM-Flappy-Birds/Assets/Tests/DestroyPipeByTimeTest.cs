using System.Collections;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine;

public class DestroyPipeByTimeTest
{

    [Test]
    public void DestroyPipeByTimeTestSimplePasses()
    {
        // Use the Assert class to test conditions.
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator DestroyPipeByTimeTestWithEnumeratorPasses()
    {
        return null;
    }

    // Pipes should be destroyed immediately on game over
    [Test]
    public void DestroyPipesOnGameOverWithEnumeratorPasses()
    {
        // create pipes
        GameObject pipeObject = new GameObject();
        pipeObject.AddComponent<DestroyPipeByTime>();

        GameObject gameManager = new GameObject();
        gameManager.AddComponent<GameManager>();
        gameManager.GetComponent<GameManager>().Awake();
        GameManager.gameInstance.SetGameOver();

        if (GameManager.gameInstance.IsGameOver())
        {
            pipeObject.GetComponent<DestroyPipeByTime>().DestroyPipeImmediately();
        }

        Assert.IsTrue(pipeObject == null);
    }
}