using UnityEngine;

public class DestroyPipeByTime : MonoBehaviour 
{
    private GameObject pipe;
    public GameObject parentObject;

    // Update is called once per frame
    public void Update()
    {
        if (gameObject == null)
        {
            Debug.Log("pipe game object is null");
        }
        else
        {
            Debug.Log("pipe game object is not null");
        }

        DestroyPipes();
    }

    public void DestroyPipes()
    {
        SaveParentObject();
        if (GameManager.gameInstance.IsGameOver())
        {
            DestroyPipeImmediately();
        }
        else
        {
            Destroy(pipe, 8);
        }
    }

    public void SaveParentObject()
    {
        pipe = parentObject;

    }

    public void DestroyPipeImmediately()
    {
        Debug.Log("DestroyPipeImmediately()");
        DestroyImmediate(pipe, true);
    }
}
