using UnityEngine;

public class MusicManager : MonoBehaviour,IMoodObserver
{
    public AudioSource audioSource;
    public AudioClip calmMusic;
    public AudioClip sadMusic;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on MusicManager.");
        }
        MoodManager.Instance.RegisterObserver(this);
    }
    public void OnMoodChanged(Mood newMood)
    {
        if (newMood == Mood.Calm)
        {
            Debug.Log("Mood changed to Calm. Playing calm music.");
            PlayCalmMusic();
        }
        else if (newMood == Mood.Sad)
        {
            Debug.Log("Mood changed to Sad. Playing sad music.");
            PlaySadMusic();
        }
    }

    public void PlayCalmMusic()
    {
        audioSource.clip = calmMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlaySadMusic()
    {
        audioSource.clip = sadMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
