using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class EnvironmentGeneratorTest
{
    public GameObject[] backgrounds;

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
      GameObject environment = new GameObject();
        if (gameObject == null)
        {
            Debug.Log("game object is null");
        } 
        else
        {
            
            gameObject.AddComponent<EnvironmentGenerator>();
            if (gameObject.GetComponent<EnvironmentGenerator>() != null)
            {
               
                environment = (GameObject)gameObject.GetComponent<EnvironmentGenerator>().InstantiateEnvironment();

               Assert.IsNotNull(environment, "environment is null");
            }
            else
            {
                Debug.Log("environmentShows is null");
            }

        }
            yield return null;
    }

}