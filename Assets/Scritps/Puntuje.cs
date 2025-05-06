using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
public class Puntuje : MonoBehaviour
{
    private int score = 0;
    public TMP_Text scoreText;

    void Start()
    {
        EventManager.Instance.OnHealthChanged.Raise(score);
        Coin.OnCoinTouched += IncreaseScore;
       
    }
    void IncreaseScore()
    {
        score++;
        EventManager.Instance.OnScoreChanged.Raise(score); 
        UpdateScoreText(score);
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
        EventManager.Instance.OnScoreChanged.Raise(score);
        Coin.OnCoinTouched -= IncreaseScore;
    }
}


