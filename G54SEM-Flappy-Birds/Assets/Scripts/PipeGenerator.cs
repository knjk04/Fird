using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour {

    public GameObject[] PipeSet;
    public Vector2 SpawnValues;
    public float SpawnWait = 2;

    // Start is called before the first frame update
    void Start()
    {
        // Starts creation subroutine
        StartCoroutine(SpawnPipe());
    }

    IEnumerator SpawnPipe()
    {
        while (true)
        {
            // Chooses random pipe height pair
            int PipeSpriteChoice = Random.Range(0, PipeSet.Length);

            // Setting parameters and creates pipe pair
            Vector2 SpawnPosition = new Vector2(2.0f, 0.165f);
            Quaternion Rotation = Quaternion.identity;
            GameObject Pipe = Instantiate(PipeSet[PipeSpriteChoice], SpawnPosition, Rotation);

            // Wait for x seconds (where x is spawnWait) before creating another set
            yield return new WaitForSeconds(SpawnWait);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        
    }

}
