using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // single instance
    public static GameManager gameInstance;
    public BirdGenerator birdGenerator;
    public BirdCollisions birdCollisions;
    public BirdMovement bird;

    public GameObject gameOverPanel;
    public GameObject pipeGenerator;
    private GameObject pipeScript;
    public GameObject scorePanel;
    public GameObject getReadyPanel;
    public GameObject goldMedal;
    public Rigidbody2D birdRigidBody2D;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI highScoreText;
    public Button playButton;

    public AudioSource pointSound;
    public AudioSource backgroundAudio;

    private bool firstGame = true;
    private bool gameOver = false;
    private bool gameStarted = false;
    private int playerScore = 0;
    private int highScore = 0;

    void Start()
    {
        InitialSetup();
    }

    public void Awake()
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
            PostReadySetup();
        }
    }

    /// <summary>
    /// Called when script is created, start of game initialisation.
    /// </summary>
    public void InitialSetup()
    {
        gameOverScoreText.enabled = false;
        highScoreText.enabled = false;
        PlayBackgroundAudioOnGameStart();
    }

    /// <summary>
    /// Plays background music on game start.
    /// </summary>
    public void PlayBackgroundAudioOnGameStart()
    {
        if (backgroundAudio != null)
        {
            backgroundAudio.Play();
        }
        else
        {
            Debug.LogError("Background audio is null");
        }
    }

    /// <summary>
    /// Setup function used to set up game once user has clicked the ready button.
    /// </summary>
    void PostReadySetup()
    {
        playButton.gameObject.SetActive(false);

        gameStarted = true;
        // Create scene and show score
        getReadyPanel.SetActive(false);
        scorePanel.SetActive(true);

        // Introduce gravity and allow bird to fall
        birdRigidBody2D.gravityScale = 1f;

        // Start pipe generation
        Vector2 spawnPosition = new Vector2(0.0f, 0.0f);
        Quaternion rotation = Quaternion.identity;
        pipeScript = Instantiate(pipeGenerator, spawnPosition, rotation);
    }

    /// <summary>
    /// Function handles resetting the game to start state.
    /// </summary>
    private void RestartGame()
    {
        // UI components update
        gameOverPanel.SetActive(false);
        getReadyPanel.SetActive(true);
        scorePanel.SetActive(true);
        playButton.gameObject.SetActive(false);

        gameOverScoreText.enabled = false;
        highScoreText.enabled = false;
        goldMedal.SetActive(false);

        // Reset bird position
        bird.ResetBird();
        birdRigidBody2D.gravityScale = 0f;

        ResetScore();

        scoreText.text = playerScore.ToString();
        scoreText.enabled = true;
        
        firstGame = false;

        // Randomly update bird sprite
        birdGenerator.UpdateBirdSprite();

        birdCollisions.ResetCollisionSoundEffectPlayed();

        gameOver = false;
    }

    /// <summary>
    /// Function resets score to 0.
    /// </summary>
    public void ResetScore()
    {
         playerScore = 0;
    }

    /// <summary>
    /// 
    /// </summary>
    public void RunGame()
    {
        RestartGame();
    }

    /// <summary>
    /// Handles logic when user gets a point.
    /// </summary>
    public void UpdateScore()                          
    {
        AddScore();
        // Changes score displayed to user
        scoreText.text = playerScore.ToString();

        if (pointSound != null)
        {
            pointSound.Play();
        }
        else
        {
            Debug.LogError("Point sound is null");
        }
    }

    /// <summary>
    /// Getter for int playerScore.
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        return playerScore;
    }

    /// <summary>
    /// Function increments int playerScore.
    /// </summary>
    public void AddScore()
    {
        playerScore++;
    }

    /// <summary>
    /// Handles logic and UI updates when game has ended.
    /// </summary>
    public void EndGame()                          
    {
        // Handles logic when game finishes (bird has crashed)
        gameOverPanel.SetActive(true);
        gameOver = true;
        gameStarted = false;

        // Stop pipe creation script
        Destroy(pipeScript);
        scoreText.enabled = false;

        // Show game over UI objects and score
        gameOverScoreText.text = scoreText.text;
        gameOverScoreText.enabled = true;
        highScoreText.enabled = true;

        // Updates score if required
        if (SetHighScore())
        {
            if (!firstGame)
            {
                goldMedal.SetActive(true);
            }
 
            highScoreText.text = scoreText.text;
        }
        else
        {
            highScoreText.text = highScore.ToString();
        }
        playButton.gameObject.SetActive(true);
    }

    /// <summary>
    /// Function updates high score if required.
    /// </summary>
    /// <returns>boolean to represent whether high score has been updated.</returns>
    public bool SetHighScore()
    {
        if (highScore < playerScore)
        {
            highScore = playerScore;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Getter for boolean gameOver.
    /// </summary>
    /// <returns>gameOver boolean</returns>
    public bool IsGameOver()
    {
        return gameOver;
    }

    /// <summary>
    /// Getter for playerScore.
    /// </summary>
    /// <returns>playerScore boolean</returns>
    public int GetPlayerScore()
    {
        return playerScore;
    }

    /// <summary>
    /// Getter for highscore int.
    /// </summary>
    /// <returns>highScore int</returns>
    public int GetHighScore()
    {
        return highScore;
    }

    // This should only be called if the bird collides with the ceiling, ground or one of the pipes
    /// <summary>
    /// Setter for gameOver boolean.
    /// </summary>
    public void SetGameOver()
    {
        gameOver = true;
    }

    /// <summary>
    /// Getter for AudioSource backGroundAudio.
    /// </summary>
    /// <returns>backGroundAudio AudioSource</returns>
    public AudioSource GetBackgroundAudioSource()
    {
        return backgroundAudio;
    }

    // For use only in the test suite
    /// <summary>
    /// Setter for AudioSource. Used with testing suite.
    /// </summary>
    /// <param name="backgroundAudio">AudioSource passed from testing suite.</param>
    public void SetAudioSource(AudioSource backgroundAudio)
    {
        this.backgroundAudio = backgroundAudio;
    }
}