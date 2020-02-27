using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // single instance
    public static GameManager gameInstance;

    public GameObject gameOverPanel;
    
    // score text
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI highScoreText;
    public BirdMovement bird;

    public GameObject pipeGenerator;
    private GameObject pipeScript;
 
    public GameObject scorePanel;
    public GameObject getReadyPanel;

    public Rigidbody2D birdRigidBody2D;

    private bool gameOver = false;

    // used to handle start of game event
    private bool gameStarted = false;
    public AudioSource backgroundAudio;

    private int playerScore = 0;
    private int highScore = 0;
    private bool firstGame = true;

    public AudioSource pointSound;

    public Button playButton;

    public GameObject goldMedal;

    //public GameObject birdGenerator;
    public BirdGenerator birdGenerator;

    void Start()
    {
        gameOverScoreText.enabled = false;
        highScoreText.enabled = false;
    }

    void Awake()
    {
        if (gameInstance != null && gameInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            // Set single instance
            gameInstance = this;
        }
    }

    void Update()
    {
        // Start game on click 
        if (!gameOver && (Input.GetButtonDown("Fire1") && gameStarted == false))
        {
            Debug.Log("User is ready");
            SetupGame();
        }
    }

    void SetupGame()
    {
        playButton.gameObject.SetActive(false);

        gameStarted = true;
        // Create scene and show score
        getReadyPanel.SetActive(false);
        scorePanel.SetActive(true);

        // Introduce gravity and allow bird to fall
        birdRigidBody2D.gravityScale = 1f;

        if (backgroundAudio != null)
        {
            backgroundAudio.Play();
        }
        else
        {
            Debug.Log("Background audio is null");
        }

        // Start pipe generation
        Vector2 spawnPosition = new Vector2(0.0f, 0.0f);
        Quaternion rotation = Quaternion.identity;
        pipeScript = Instantiate(pipeGenerator, spawnPosition, rotation);
    }

    private void RestartGame()
    {
        Debug.Log("GameOver panel should not showing");
        gameOverPanel.SetActive(false);
        getReadyPanel.SetActive(true);
        scorePanel.SetActive(true);
        playButton.gameObject.SetActive(false);

        gameOverScoreText.enabled = false;
        highScoreText.enabled = false;
        //GoldMedal.enabled = false;
        goldMedal.SetActive(false);

        bird.ResetBird();
        birdRigidBody2D.gravityScale = 0f;

        playerScore = 0;
        scoreText.text = playerScore.ToString();
        scoreText.enabled = true;

        firstGame = false;

        birdGenerator.UpdateBirdSprite();


        gameOver = false;
    }

    public void RunGame()
    {
        Debug.Log("Run game");
        RestartGame();
    }

    public void AddScore()                          
    {
        Debug.Log("Incrementing score. Score before = " + playerScore + ", score now = " + (playerScore + 1));
        playerScore++;
        // Changes score displayed to user
        scoreText.text = playerScore.ToString();

        if (pointSound != null)
        {
            pointSound.Play();
        }
        else
        {
            Debug.Log("Point sound is null");
        }
        

    }

    public void EndGame()                          
    {
        Debug.Log("in end game");
        

        // Handles logic when game finishes (bird has crashed)
        gameOverPanel.SetActive(true);
        gameOver = true;
        gameStarted = false;
        // Stop pipe creation script
        Destroy(pipeScript);
        scoreText.enabled = false;

       
        gameOverScoreText.text = scoreText.text;
        gameOverScoreText.enabled = true;
        highScoreText.enabled = true;

        if (SetHighScore())
        {
            //GoldMedal.enabled = true;
            if (!firstGame)
            {
                goldMedal.SetActive(true);
            }
 
            Debug.Log("Show the medal");
            highScoreText.text = scoreText.text;
        }
        else
        {
            highScoreText.text = highScore.ToString();
        }
        playButton.gameObject.SetActive(true);
    }

    bool SetHighScore()
    {
        if (highScore < playerScore)
        {
            highScore = playerScore;
            return true;
        }
        return false;
    }

    public bool IsGameOver()
    {
        //Debug.Log("GameOver = " + GameOver);
        return gameOver;
    }
}