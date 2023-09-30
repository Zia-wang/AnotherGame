using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverText;
    public GameObject winText;
    public GameObject restardButton;
    public Text scoreText;

    private int coinValue = 1;
    private int enemyValue = 2;
    private int score;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;
        UpdateScore();
    }

    public void PlayerDied()
    {
        gameOverText.SetActive(true);
        restardButton.SetActive(true);
    }

    public void PlayerScoredCoin()
    {
        score += coinValue;
        UpdateScore();
    }

    public void PlayerScoredEnemy()
    {
        score += enemyValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void Win()
    {
        winText.SetActive(true);
        restardButton.SetActive(true);
    }
}
