using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PipeGeneratorTest
{
    [UnityTest]
    public IEnumerator PipeGeneratorTestWithEnumeratorPasses() {
        GameObject pipeGenerator = Resources.Load("Prefabs/PipePrefabs/PipeGenerator") as GameObject;
        PipeGenerator pipeGeneratorScript = pipeGenerator.GetComponent<PipeGenerator>();

        if (pipeGeneratorScript == null)
        {
            Debug.Log("null");
            Assert.IsNull(pipeGeneratorScript);
        }
        else
        { 
            pipeGeneratorScript.spawnPipe();

            float firstPipePreXPosition = pipeGeneratorScript.Pipe.GetComponent<Rigidbody2D>().transform.position.x;
            Debug.Log("firstPipePreXPosition = " + pipeGeneratorScript.Pipe.GetComponent<Rigidbody2D>().transform.position.x);

            yield return new WaitForSeconds(pipeGeneratorScript.SpawnWait);

            float firstPipePostXPosition = pipeGeneratorScript.Pipe.GetComponent<Rigidbody2D>().transform.position.x;
            Debug.Log("firstPipePostXPosition = " + pipeGeneratorScript.Pipe.GetComponent<Rigidbody2D>().transform.position.x);

            Assert.IsTrue(firstPipePreXPosition > firstPipePostXPosition);
        }
        yield return null;
        

    }
}
