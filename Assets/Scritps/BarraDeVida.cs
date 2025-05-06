using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.GameEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarraDeVida : MonoBehaviour
{
    public int Life;
    public GameObject[] Lifes;
    public Contador contador;

   

    void Start()
    {
        ActivateLives();
        EventManager.Instance.OnHealthChanged.Raise(Life);
    }

    void HandleHealthGained()
    {
        Life++;
        EventManager.Instance.OnHealthChanged.Raise(Life); 
        UpdateLife();
    }

    public void UpdateLife()
    {
        for (int i = 0; i < Lifes.Length; i++)
        {
            Lifes[i].SetActive(i < Life);
        }

        if (Life < 1)
        {
            contador.CambiarEscenaGameOver();
        }
    }

    public void TakeDamage(int damage)
    {
        Life -= damage;
        EventManager.Instance.OnHealthChanged.Raise(Life); // Cambiado a Raise
        UpdateLife();
    }
    void ActivateLives()
    {
        for (int i = 0; i < Lifes.Length; i++)
        {
            Lifes[i].SetActive(true);
        }
    }

    void OnDestroy()
    {
        EventManager.Instance.OnHealthChanged.Raise(Life);    
    }
}
