using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour 
{
    // Ensure this is initialised in the inspector:
    public GameObject[] backgrounds;
    private GameObject environment;
  //  private int pipeSpriteChoice;
    //private Vector2 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
       // environmentShows = false;
        SetBackground();
    }

    void SetBackground()
    {
        if (backgrounds.Length < 1)
        {
            Debug.Log("The environments array is empty. Please initialise it.");
        }
        else
        {
            
            environment = InstantiateEnvironment();
            
        }        
    }

    public GameObject InstantiateEnvironment()
    {
        int pipeSpriteChoice = Random.Range(0, backgrounds.Length);
        Vector2 spawnPosition = new Vector2(0.0f, 0.0f);
        return Instantiate(backgrounds[pipeSpriteChoice], spawnPosition, Quaternion.identity);
    }
}
