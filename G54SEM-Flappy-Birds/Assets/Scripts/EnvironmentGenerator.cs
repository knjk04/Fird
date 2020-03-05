using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour 
{
    // Ensure this is initialised in the inspector:
    public GameObject[] backgrounds;

    void Start()
    {
        InstantiateEnvironment(backgrounds);
    }

    // This accepts as a parameter a global variable so that this can work with the test suite
    /// <summary>
    /// Function initialises environment, randomly choosing day or night.
    /// </summary>
    /// <param name="backgrounds">GameObject array consisting of the day and night prefabs</param>
    /// <returns>Environment Gameobject or null if array empty</returns>
    public GameObject InstantiateEnvironment(GameObject[] backgrounds)
    {
        if (backgrounds.Length < 1)
        {
            Debug.LogError("The environments array is empty. Please initialise it.");
            return null;
        }

        // Instantiate environment with random choice between day/night prefab
        int backgroundSpriteChoice = Random.Range(0, backgrounds.Length);
        Vector2 spawnPosition = new Vector2(0.0f, 0.0f);
        return Instantiate(backgrounds[backgroundSpriteChoice], spawnPosition, Quaternion.identity);
    }
}
