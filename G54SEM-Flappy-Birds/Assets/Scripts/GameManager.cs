using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    // single instance
    public static GameManager instance;

    // game over UI
    public GameObject gameover;    
    // score text
    public TextMeshProUGUI Score;

    // mark current game status
    private bool gameOver = false;
    // store score.
    private int score = 0;

    public AudioSource PointSound;

    void Start()
    {
        //Score = GetComponent<TextMeshProUGUI>();
    }

    void Awake()
    {
        if (instance == null)
        {
            // set single instance
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
        {         
            // if gameover and click the picture, restart the game.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddScore()                          
    {

        //when the bird cross a obstacle, add score.
        //if (gameover)
        //    return;
        score++;
        Score.text = score.ToString();

        PointSound.Play();
    }

    public void GameOver()                          
    {
        Debug.Log("over");
        gameover.SetActive(true);
        gameOver = true;
    }
}
