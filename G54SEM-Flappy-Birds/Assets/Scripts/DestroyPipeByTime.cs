using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPipeByTime : MonoBehaviour 
{

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameInstance.IsGameOver())
        {
            //Debug.Log("Are you dead yet?");
            Destroy(gameObject);
            //Bird.DestroyBird();
        }
        else
        {
            //Debug.Log("Game is not over");
            Destroy(gameObject, 8);
        }
    }
}
