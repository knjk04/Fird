using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdCollisions : MonoBehaviour 
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(CheckIfScoreBox(collision.gameObject.tag))
        {
            GameManager.gameInstance.EndGame();
        }
    }

    public bool CheckIfScoreBox(string tag)
    {
        GameManager.gameInstance.SetGameOver();
        return (tag != "score-box");
    }
}
