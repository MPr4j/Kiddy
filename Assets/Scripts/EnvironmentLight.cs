using UnityEngine;

public class EnvironmentLight : MonoBehaviour, IMoodObserver
{
    public Light roomLight;
    void Start()
    {
        roomLight = GetComponent<Light>();
        MoodManager.Instance.RegisterObserver(this);
    }

    public void OnMoodChanged(Mood newMood)
    {
        switch (newMood)
        {
            case Mood.Calm:
                roomLight.color = Color.cyan;
                break;
            case Mood.Sad:
                roomLight.color = Color.gray;
                break;
        }
    }
    public void ToggleLight(bool isOn)
    {
        if (roomLight != null)
        {
            roomLight.enabled = isOn;
        }
    }
}
