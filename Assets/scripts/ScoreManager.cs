using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public float scoreIncreaseInterval = 1.0f; // Time interval for increasing the score
    public int scoreIncreaseAmount = 1; // Amount to increase the score each interval

    private int currentScore = 0;
    private bool isGameOver = false;

    private static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(IncreaseScoreOverTime());
    }

    private IEnumerator IncreaseScoreOverTime()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(scoreIncreaseInterval);
            UpdateScore(scoreIncreaseAmount);
        }
    }

    public void UpdateScore(int score)
    {
        if (!isGameOver)
        {
            currentScore += score;
            UpdateScoreUI();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        PlayerPrefs.SetInt("FinalScore", currentScore); // Store the final score
        PlayerPrefs.Save();
        // You can display the game over screen here
        // You can also load the game over scene
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    private void UpdateScoreUI()
    {
        scoreText.text = currentScore.ToString();
    }
}
