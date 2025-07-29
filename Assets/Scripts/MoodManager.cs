using System;
using System.Collections.Generic;
using UnityEngine;

public class MoodManager : MonoBehaviour
{
    public static MoodManager Instance;
    private List<IMoodObserver> observers = new List<IMoodObserver>();
    private Mood currentMood = Mood.Calm;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // if you need it across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterObserver(IMoodObserver observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);
    }

    public void RemoveObserver(IMoodObserver observer)
    {
        observers.Remove(observer);
    }

    public void SetMood(Mood newMood)
    {
        currentMood = newMood;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var obs in observers)
        {
            Debug.Log($"Notifying observer: {obs.GetType().Name} of mood change to {currentMood}");
            obs.OnMoodChanged(currentMood);
        }
    }

    public Mood GetCurrentMood()
    {
        return currentMood;
    }
}
