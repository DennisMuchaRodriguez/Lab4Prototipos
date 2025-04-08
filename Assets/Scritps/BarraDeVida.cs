using System.Collections;
using System.Collections.Generic;
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
        EventManager.Instance.OnHealthGained.AddListener(HandleHealthGained);
    }

    void HandleHealthGained()
    {

        Life++;
        EventManager.Instance.OnHealthChanged.Invoke(Life);
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
        EventManager.Instance.OnHealthChanged.Invoke(Life);
        EventManager.Instance.OnHealthLost.Invoke();
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
        EventManager.Instance.OnHealthGained.RemoveListener(HandleHealthGained);    
    }
}
