using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager GameInstance;         // single instance

    public GameObject GameOverPanel;                // game over UI
    public TextMeshProUGUI ScoreUI;                 // score text
    public GameObject PipeGenerator;                // pipe generation script
    public GameObject PipeScript;
    public GameObject ScorePanel;                   // score
    public GameObject GetReadyPanel;                // Welecome panel
    public Rigidbody2D BirdRigidBody;               // bird rigidbody object


    private bool GameOverBool = false;              // mark current game status
    private bool Started = false;                   // used to handle start of game event
    private int ScoreInt = 0;                       // store score.

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
        if (GameOverBool == true && Input.GetMouseButtonDown(0))
        {   // If gameover and user clicks, restart the game.
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
        ScoreInt++;
        // Changes score displayed to user
        ScoreUI.text = ScoreInt.ToString();
    }

    public void GameOver()                          
    {
        // Handles logic when game finishes (bird has crashed)
        GameOverPanel.SetActive(true);
        GameOverBool = true;
        Started = false;
        // Stop pipe creation script
        Destroy(PipeScript);
    }
}