using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour {

    public GameObject[] pipeSet;
    public Vector2 spawnValues;
    public float spawnWait = 2;
    public bool running = false;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    IEnumerator SpawnPipe()
    {
        while (true)
        {
            int pipeSpriteChoice = Random.Range(0, pipeSet.Length);
            Vector2 spawnPosition = new Vector2(2.0f, 0.165f);
            Quaternion rotation = Quaternion.identity;
            GameObject pipe = Instantiate(pipeSet[pipeSpriteChoice], spawnPosition, rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }

    // Update is called once per frame
    void Update () {
        /*if (Input.GetButtonDown("Fire1") && running == false)
        {
            Debug.Log("starting coroutine, running = " + running);
            running = true;
            StartCoroutine(SpawnPipe());

        }
        */
        /*
        if()
        {
            running = false;
            StopCoroutine(SpawnPipe());
            return;
        }
        */
    }

}
