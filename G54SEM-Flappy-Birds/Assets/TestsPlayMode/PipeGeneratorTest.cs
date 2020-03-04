using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PipeGeneratorTest {

    //[Test]
    //public void PipeGeneratorTestSimplePasses() {
    //    // Use the Assert class to test conditions.
    //}

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator PipeGeneratorTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        GameObject pipeGenerator = Resources.Load("Prefabs/PipePrefabs/PipeGenerator") as GameObject;
        PipeGenerator pipeGeneratorScript = pipeGenerator.GetComponent<PipeGenerator>();

        if (pipeGeneratorScript == null)
        {
            Debug.Log("null");
        }
        else
        {
            Debug.Log("not null");
        }

        Debug.Log("spawn wait = " + pipeGeneratorScript.SpawnWait);

        yield return new WaitForSeconds(pipeGeneratorScript.SpawnWait);
        //yield return null;

        
    }
}
