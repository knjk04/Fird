using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

// Tests whether Instaniate
public class EnvironmentGeneratorTest
{
    /// <summary>
    /// Tests whether environment gets generated correctly.
    /// </summary>
    /// <returns>Returns IEnumerator</returns>
    [UnityTest]
    public IEnumerator EnvironmentGeneratorTestWithEnumeratorPasses()
    {
        GameObject gameObject = new GameObject();
        GameObject environment = new GameObject();
        GameObject day = Resources.Load("Prefabs/EnvironmentPrefabs/EnvironmentDay") as GameObject;
        GameObject night = Resources.Load("Prefabs/EnvironmentPrefabs/EnvironmentNight") as GameObject;
        GameObject[] backgrounds = { day, night };

        gameObject.AddComponent<EnvironmentGenerator>();
        if (gameObject.GetComponent<EnvironmentGenerator>() != null)
        {
            environment = gameObject.GetComponent<EnvironmentGenerator>().InstantiateEnvironment(backgrounds);
            Assert.IsNotNull(environment, "environment is null");
        }
        else
        {
            Debug.LogError("environment generator is not a component of the game object");
        }
        yield return null;
    }
}