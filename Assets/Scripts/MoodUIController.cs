using UnityEngine;

public class MoodUIController : MonoBehaviour
{
    public void SetCalmMood() => MoodManager.Instance.SetMood(Mood.Calm);
    public void SetSadMood() => MoodManager.Instance.SetMood(Mood.Sad);
}
