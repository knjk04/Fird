using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class EnvironmentGeneratorTest
{

    [Test]
    public void EnvironmentGeneratorTestSimplePasses()
    {
        // Use the Assert class to test conditions.
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator EnvironmentGeneratorTestWithEnumeratorPasses()
    {
        GameObject gameObject = new GameObject();


        if (gameObject == null)
        {
            Debug.Log("game object is null");
        }
        else
        {
            Debug.Log("game object is not null");
            
        }
            yield return null;
    }

}