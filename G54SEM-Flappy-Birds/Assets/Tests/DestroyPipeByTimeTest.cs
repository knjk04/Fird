using NUnit.Framework;
using UnityEngine;

public class DestroyPipeByTimeTest
{
    /// <summary>
    /// Tests if pipes are destroyed immediately on game over.
    /// </summary>
    [Test]
    public void DestroyPipesImmediatelyOnGameOverTest()
    {
        // create pipes
        GameObject pipeInMemory = Resources.Load("Prefabs/PipePrefabs/pipe-set-test") as GameObject;
        GameObject pipe = Object.Instantiate(pipeInMemory);

        if (pipe == null)
        {
            Debug.LogError("pipeObject == null");
        }
        else
        {
            GameObject gameManager = new GameObject();
            gameManager.AddComponent<GameManager>();
            gameManager.GetComponent<GameManager>().Awake();
            GameManager.gameInstance.SetGameOver();
            pipe.GetComponent<DestroyPipeByTime>().DestroyPipes();

            Assert.IsTrue(pipe == null);
        }
    }
}