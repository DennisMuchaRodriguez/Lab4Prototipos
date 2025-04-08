using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    
    public UnityEvent OnGameWin;
    public UnityEvent OnGameWin2;
    public UnityEvent OnGameOver;
    public UnityEvent<int> OnScoreChanged;
    public UnityEvent<int> OnHealthChanged;
    public UnityEvent OnHealthGained;
    public UnityEvent OnHealthLost;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

         
            if (OnGameWin == null) OnGameWin = new UnityEvent();
            if (OnGameWin2 == null) OnGameWin2 = new UnityEvent();
            if (OnGameOver == null) OnGameOver = new UnityEvent();
            if (OnScoreChanged == null) OnScoreChanged = new UnityEvent<int>();
            if (OnHealthChanged == null) OnHealthChanged = new UnityEvent<int>();
            if (OnHealthGained == null) OnHealthGained = new UnityEvent();
            if (OnHealthLost == null) OnHealthLost = new UnityEvent();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
