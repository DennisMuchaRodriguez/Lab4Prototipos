using System.Collections;
using System.Collections.Generic;
using Assets.Scritps.GameEvents;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    
    public GameIntEvent OnHealthChanged;

   
    public GameIntEvent OnScoreChanged;   

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

          
            if (OnHealthChanged == null)
                OnHealthChanged = ScriptableObject.CreateInstance<GameIntEvent>();
            if (OnScoreChanged == null)
                OnScoreChanged = ScriptableObject.CreateInstance<GameIntEvent>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
