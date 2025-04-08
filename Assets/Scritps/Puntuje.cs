using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Puntuje : MonoBehaviour
{
    private int score = 0;
    public TMP_Text scoreText;

    void Start()
    {
        EventManager.Instance.OnScoreChanged.AddListener(UpdateScoreText);
        Coin.OnCoinTouched += IncreaseScore;
       
    }
    void IncreaseScore()
    {
        score++;
        EventManager.Instance.OnScoreChanged.Invoke(score);
    }
    void UpdateScoreText(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + newScore.ToString();
        }
    }
    void OnDestroy()
    {
        EventManager.Instance.OnScoreChanged.RemoveListener(UpdateScoreText);
        Coin.OnCoinTouched -= IncreaseScore;
    }
}


