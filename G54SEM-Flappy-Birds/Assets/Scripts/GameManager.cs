using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;             // single instance

    public GameObject gameover;                 // game over UI
    public TextMeshProUGUI Score;                          // score text

    private bool gameOver = false;                  // mark current game status
    private int score = 0;                          // store score.

    void Start()
    {
        //Score = GetComponent<TextMeshProUGUI>();
    }

    void Awake()
    {
        if (instance == null)
        {                     // set single instance
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {         // if gameover and click the picture, restart the game.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddScore()                          
    {

        //when the bird cross a obstacle, add score.
        //if (gameover)
        //    return;
        Debug.Log("log");
        score++;
        Score.text = score.ToString();
    }

    public void GameOver()                          // game over function.
    {
        Debug.Log("over");
        gameover.SetActive(true);
        gameOver = true;
    }
}
