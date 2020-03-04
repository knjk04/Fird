using System.Collections;
using UnityEngine;

public class PipeGenerator : MonoBehaviour {

    // Ensure the following are initialised in the inspector
    public GameObject[] PipeSet;
    public Vector2 SpawnValues;
    public float SpawnWait;
    public GameObject Pipe;

    // Start is called before the first frame update
    public void Start()
    {
        // Starts creation subroutine
        StartCoroutine(SpawnPipe());
        Debug.Log("start");
    }

    public IEnumerator SpawnPipe()
    {
        while (true)
        {

            if (PipeSet.Length == 0)
            {
                Debug.Log("Ensure PipeSet is initialised");
            }
            else
            {

                if (PipeSet == null)
                {
                    Debug.Log("pipe set is null");
                }

                spawnPipe();

                // Wait for x seconds (where x is spawnWait) before creating another set
                yield return new WaitForSeconds(SpawnWait);
            }
        }
    }

    public void spawnPipe()
    {
        // Choose random pipe set
        int PipeSpriteChoice = Random.Range(0, PipeSet.Length);

        // Set parameters and create pipe pair
        Vector2 SpawnPosition = new Vector2(2.0f, 0.165f);
        Quaternion Rotation = Quaternion.identity;
        Pipe = Instantiate(PipeSet[PipeSpriteChoice], SpawnPosition, Rotation);
        Pipe.AddComponent<Rigidbody2D>();
        Pipe.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

        Pipe.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f, 0.0f);
        Debug.Log("spawn pipe complete");
    }

}
