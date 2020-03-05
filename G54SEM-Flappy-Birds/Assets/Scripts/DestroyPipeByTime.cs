using UnityEngine;

public class DestroyPipeByTime : MonoBehaviour 
{
    private GameObject pipe;
    public GameObject parentObject;
    public int pipeLifeSeconds = 8;

    // Update is called once per frame
    public void Update()
    {
        DestroyPipes();
    }

    /// <summary>
    /// Function handles destorying the pipes
    /// </summary>
    public void DestroyPipes()
    {
        SaveParentObject();
        // Destorys all pipes when game ends
        if (GameManager.gameInstance.IsGameOver())
        {
            DestroyPipeImmediately();
        }
        else
        {
            // Pipe object destroyed after 8 seconds
            Destroy(pipe, pipeLifeSeconds);
        }
    }

    /// <summary>
    /// Function makes a copy of pipe parent object.
    /// </summary>
    public void SaveParentObject()
    {
        pipe = parentObject;
    }

    /// <summary>
    /// Function destroys pipes immediately
    /// </summary>
    public void DestroyPipeImmediately()
    {
        DestroyImmediate(pipe, true);
    }
}
