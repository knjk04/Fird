using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;


 public class DestroyPipeBySecondsTest
{ 
	[UnityTest]
    public IEnumerator DestroyPipeBySecondsTestWithEnumeratorPasses()
	{
        GameObject memPipe = Resources.Load("Prefabs/PipePrefabs/pipe-set-test") as GameObject;
        GameObject pipe = Object.Instantiate(memPipe);

        if (pipe == null)
        {
            Debug.Log("null pipe");
        }
        else
        {
            Debug.Log("pipe is not null");
        }

        pipe.AddComponent<GameManager>();
        GameManager gameManager = pipe.GetComponent<GameManager>();
        gameManager.GetComponent<GameManager>().Awake();

        DestroyPipeByTime destroyPipeByTime = pipe.GetComponent<DestroyPipeByTime>();

        destroyPipeByTime.SaveParentObject();
        destroyPipeByTime.DestroyPipeImmediately();

        // wait 8 seconds
        yield return new WaitForSeconds(9);;

        // check destroyed
        if (pipe == null)
        {
            Debug.Log("pipeObject successfully destroyed after 8 seconds");
        } else
        {
            Debug.Log("pipeObject not destroyed after 8 seconds");
        }

        Assert.IsTrue(pipe == null);
        yield return null;
    }
}