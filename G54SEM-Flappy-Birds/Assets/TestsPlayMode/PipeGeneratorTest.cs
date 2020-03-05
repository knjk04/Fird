using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PipeGeneratorTest
{
    [UnityTest]
    public IEnumerator PipeGeneratorVelocityTest()
    {
        GameObject pipeGenerator = Resources.Load("Prefabs/PipePrefabs/PipeGenerator") as GameObject;
        PipeGenerator pipeGeneratorScript = pipeGenerator.GetComponent<PipeGenerator>();

        if (pipeGeneratorScript != null)
        {
            pipeGeneratorScript.CreatePipe();

            float firstPipePreXPosition = pipeGeneratorScript.pipe.GetComponent<Rigidbody2D>().transform.position.x;
            Debug.Log("firstPipePreXPosition = " + pipeGeneratorScript.pipe.GetComponent<Rigidbody2D>().transform.position.x);

            yield return new WaitForSeconds(pipeGeneratorScript.spawnWait);

            float firstPipePostXPosition = pipeGeneratorScript.pipe.GetComponent<Rigidbody2D>().transform.position.x;
            Debug.Log("firstPipePostXPosition = " + pipeGeneratorScript.pipe.GetComponent<Rigidbody2D>().transform.position.x);

            Assert.IsTrue(firstPipePreXPosition > firstPipePostXPosition);
        }
        else
        {
            Debug.LogError("pipeGeneratorScript == null");
        }
        yield return null;
    }
}
