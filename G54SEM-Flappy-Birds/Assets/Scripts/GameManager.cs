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

    public Rigidbody2D birdRB;
    public TextMeshProUGUI GameOverScore;
    public TextMeshProUGUI HighScoreUI;


    private bool GameOver = false;
    //private bool GameOver;


    // used to handle start of game event
    private bool Started = false;
    public AudioSource BackgroundAudio;

    private int PlayerScore = 0;
    private int HighScore = 0;

    public AudioSource PointSound;

    public Button PlayButton;


    void Start()
    {
        GameOverScore.enabled = false;
        HighScoreUI.enabled = false;
        //GameOver = false;
    }

    void Awake()
    {
        if (GameInstance != null && GameInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            // Set single instance
            GameInstance = this;
        }
    }

    public static GameManager GetInstance
    {
        get {
            return GameInstance;
        }
    }

    void Update()
    {
        // Start game on click 
        if (!GameOver && (Input.GetButtonDown("Fire1") && Started == false))
        {
            Debug.Log("User is ready");
            SetupGame();
        }
    }

    void SetupGame()
    {

        PlayButton.gameObject.SetActive(false);

        Started = true;
        // Create scene and show score
        GetReadyPanel.SetActive(false);
        ScorePanel.SetActive(true);

        // Introduce gravity and allow bird to fall
        BirdRigidBody.gravityScale = 1f;

        if (BackgroundAudio != null)
        {
            BackgroundAudio.Play();
        }
        else
        {
            Debug.Log("Background audio is null");
        }

        // Start pipe generation
        Vector2 spawnPosition = new Vector2(0.0f, 0.0f);
        Quaternion rotation = Quaternion.identity;
        PipeScript = Instantiate(PipeGenerator, spawnPosition, rotation);
    }

    public void RunGame()
    {
        Debug.Log("Run game");
    }

    public void AddScore()                          
    {
        PlayerScore++;
        // Changes score displayed to user
        ScoreUI.text = PlayerScore.ToString();

        if (PointSound != null)
        {
            PointSound.Play();
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
        GameOverPanel.SetActive(true);
        GameOver = true;
        Started = false;
        // Stop pipe creation script
        Destroy(PipeScript);
        ScoreUI.enabled = false;

       
        GameOverScore.text = ScoreUI.text;
        GameOverScore.enabled = true;
        HighScoreUI.enabled = true;

        if (SetHighScore())
        {
            HighScoreUI.text = ScoreUI.text;
        }
        else
        {
            HighScoreUI.text = HighScore.ToString();
        }
        PlayButton.gameObject.SetActive(true);
    }

    bool SetHighScore()
    {
        if (HighScore < PlayerScore)
        {
            HighScore = PlayerScore;
            return true;
        }
        return false;
    }

    public bool IsGameOver()
    {
        Debug.Log("GameOver = " + GameOver);
        return GameOver;
    }
}