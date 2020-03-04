using NUnit.Framework;
using UnityEngine;

public class DestroyPipeByTimeTest
{

    [Test]
    public void DestroyPipeByTimeTestSimplePasses()
    {
        // Use the Assert class to test conditions.
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