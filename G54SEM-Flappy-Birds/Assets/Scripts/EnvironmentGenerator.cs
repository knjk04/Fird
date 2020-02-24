using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour {

    public GameObject[] Envs;

    // Start is called before the first frame update
    void Start()
    {
        int PipeSpriteChoice = Random.Range(0, Envs.Length);
        Vector2 SpawnPosition = new Vector2(0.0f, 0.0f);
        Quaternion Rotation = Quaternion.identity;
        GameObject Env = Instantiate(Envs[PipeSpriteChoice], SpawnPosition, Rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
