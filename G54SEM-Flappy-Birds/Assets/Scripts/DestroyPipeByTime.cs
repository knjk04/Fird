using UnityEngine;

public class DestroyPipeByTime : MonoBehaviour 
{

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameInstance.IsGameOver())
        {
            DestroyPipeImmediately();
        }
        else
        {
            Destroy(gameObject, 8);
        }
    }

    public void DestroyPipeImmediately()
    {
        Debug.Log("DestroyPipeImmediately()");
        Object.DestroyImmediate(gameObject, true);
        //Destroy(gameObject);
    }
}
