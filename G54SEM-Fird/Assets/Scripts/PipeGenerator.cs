using System.Collections;
using UnityEngine;

public class PipeGenerator : MonoBehaviour {

    // Ensure the following are initialised in the inspector
    public GameObject[] pipeSet;
    public Vector2 spawnValues;
    public float spawnWait;
    public GameObject pipe;

    // Start is called before the first frame update
    public void Start()
    {
        // Starts creation subroutine
        StartCoroutine(SpawnPipe());
    }

    /// <summary>
    /// Coroutine does some inital checks and calls spawnPipe().
    /// </summary>
    /// <returns>Waits for spawnWait seconds before returning nothing</returns>
    public IEnumerator SpawnPipe()
    {
        while (true)
        {
            if (pipeSet.Length == 0)
            {
                Debug.LogError("Ensure PipeSet is initialised");
            }
            else
            {
                CreatePipe();

                // Wait for x seconds (where x is spawnWait) before creating another set
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }

    /// <summary>
    /// Creates and spawns a random pipe pair.
    /// </summary>
    public void CreatePipe()
    {
        // Choose random pipe set
        int PipeSpriteChoice = Random.Range(0, pipeSet.Length);

        // Set parameters
        float spawnHorizontal = 2.0f;
        float spawnVertical = 0.165f;
        float velocityHorizontal = -1.0f;
        float velocityVertical = 0.0f;

        Vector2 SpawnPosition = new Vector2(spawnHorizontal, spawnVertical);
        Quaternion Rotation = Quaternion.identity;

        // Create pipe pair
        pipe = Instantiate(pipeSet[PipeSpriteChoice], SpawnPosition, Rotation);
        pipe.AddComponent<Rigidbody2D>();
        pipe.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

        // Apply velocity
        pipe.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityHorizontal, velocityVertical);
    }

}
