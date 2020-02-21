using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour {
    public GameObject[] envs;
    // Start is called before the first frame update
    void Start()
    {
        int pipeSpriteChoice = Random.Range(0, envs.Length);
        Vector2 spawnPosition = new Vector2(0.0f, 0.0f);
        Quaternion rotation = Quaternion.identity;
        GameObject env = Instantiate(envs[pipeSpriteChoice], spawnPosition, rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
