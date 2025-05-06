using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.GameEvents;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    private float elapsedTime = 0f;
    private bool isCounting = true;

    public GameEvent OnGameWinSO;    
    public GameEvent OnGameWin2SO; 
    public GameEvent OnGameOverSO;


    void Update()
    {
        if (isCounting)
        {
            elapsedTime += Time.deltaTime;
            ActualizarTextoContador();
        }

    }

    void ActualizarTextoContador()
    {
       
        timerText.text = "Tiempo: " + ((int)elapsedTime).ToString() + "s";
    }
    public void ToggleCounting(bool isPaused)
    {
        isCounting = !isPaused;
    }

    public void CambiarEscenaGameOver()
    {
        PlayerPrefs.SetFloat("Tiempo", elapsedTime);
        OnGameOverSO.Raise(); 
        SceneManager.LoadScene("GameOver");
    }

    public void CambiarEscenaYouwin()
    {
        PlayerPrefs.SetFloat("Tiempo", elapsedTime);
        OnGameWinSO.Raise(); 
        SceneManager.LoadScene("YouWin");
    }

    public void CambiarEscenaYouwin2()
    {
        PlayerPrefs.SetFloat("Tiempo", elapsedTime);
        OnGameWin2SO.Raise(); 
        SceneManager.LoadScene("Finish");
    }
}
