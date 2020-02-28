using System.Collections;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine;

public class DestroyPipeByTimeTest : MonoBehaviour
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
    [UnityTest]
    public IEnumerator DestroyPipesOnGameOverWithEnumeratorPasses()
    {
        // create pipes

        // GameObject pipe = new GameObject();
        Object pipeObject = Resources.Load("Prefabs/PipePrefabs/pipe-set-0");


        if (pipeObject == null)
        {
            Debug.Log("pipeObject is null");
        }
        else
        {
            GameObject pipe = new GameObject();
            pipe.AddComponent<MonoBehaviour>();
            pipe = Instantiate(pipeObject) as GameObject;
            if (pipe == null)
            {
                Debug.Log("pipe is null");
            }
        }

        


        /*
        GameManager.gameInstance.SetGameOver(true);

        if(GameManager.gameInstance.IsGameOver())
        {
            
        }
        */

        return null;
    }
}