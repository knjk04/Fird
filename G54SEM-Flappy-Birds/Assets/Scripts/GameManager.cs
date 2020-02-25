using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // single instance
    public static GameManager GameInstance;
    public GameObject GameOverPanel;
    // score text
    public TextMeshProUGUI ScoreUI;
    // pipe generation script
    public GameObject PipeGenerator;
    public GameObject PipeScript;
 
    public GameObject ScorePanel;
    public GameObject GetReadyPanel;
    public Rigidbody2D BirdRigidBody;

    private bool GameOver = false;
    // used to handle start of game event
    private bool Started = false;
    private int PlayerScore = 0;                       

    void Start()
    {
    }

    void Awake()
    {
        if (GameInstance == null)
        {
            // Set single instance
            GameInstance = this;
        }
        else if (GameInstance != null)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (GameOver == true && Input.GetMouseButtonDown(0))
        {   
            // If gameover and user clicks, restart the game.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Start game on click 
        if (Input.GetButtonDown("Fire1") && Started == false)
        {
            Started = true;
            // Create scene and show score
            GetReadyPanel.SetActive(false);
            ScorePanel.SetActive(true);

            // Introduce gravity and allow bird to fall
            BirdRigidBody.gravityScale = 1f;

            // Start pipe generation
            Vector2 spawnPosition = new Vector2(0.0f, 0.0f);
            Quaternion rotation = Quaternion.identity;
            PipeScript = Instantiate(PipeGenerator, spawnPosition, rotation);
        }
    }

    public void AddScore()                          
    {
        PlayerScore++;
        // Changes score displayed to user
        ScoreUI.text = PlayerScore.ToString();
    }

    public void GameOver()                          
    {
        // Handles logic when game finishes (bird has crashed)
        GameOverPanel.SetActive(true);
        GameOver = true;
        Started = false;
        // Stop pipe creation script
        Destroy(PipeScript);
    }
}