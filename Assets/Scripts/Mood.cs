using UnityEngine;
public enum Mood
{
    Sad,
    Calm
}

public interface IMoodObserver
{
    void OnMoodChanged(Mood newMood);
}
