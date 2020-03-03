using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ScoreResetTest {
    GameObject gameManager;

    private void Setup()
    {
        gameManager = new GameObject();
        gameManager.AddComponent<GameManager>();
        gameManager.GetComponent<GameManager>().Awake();
    }

    [Test]
    public void ScoreResetTestSimplePasses() {
        int scoreStart = GameManager.gameInstance.GetScore();
        GameManager.gameInstance.UpdateScore();
        int scoreEnd = GameManager.gameInstance.GetScore();

        if (!GameManager.instance.IsGameOver())
        {

        }
    }

}
