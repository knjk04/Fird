using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour 
{

    // Ensure this is initialised in the inspector:
    public GameObject[] backgrounds;

    // Start is called before the first frame update
    void Start()
    {
        if (backgrounds.Length < 1)
        {
            Debug.Log("The environments array is empty. Please initialise it.");
        }
        else
        {
            int BGSpriteChoice = Random.Range(0, backgrounds.Length);
            Vector2 SpawnPosition = new Vector2(0.0f, 0.0f);
            Quaternion Rotation = Quaternion.identity;
            GameObject Env = Instantiate(backgrounds[BGSpriteChoice], SpawnPosition, Rotation);
        }
    }
}
