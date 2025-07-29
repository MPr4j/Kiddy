using TMPro;
using UnityEngine;

public class StoryUIManager : MonoBehaviour,IMoodObserver
{
    public StoryManager storyManager; // reference to script that loads JSON
    public TextMeshProUGUI storyTitleText;
    public TextMeshProUGUI storyDescriptionText;
    private Story currentStory;
    public void OnMoodChanged(Mood newMood)
    {
        if (newMood == Mood.Calm)
        {
             currentStory = storyManager.Stories.Find(story => story.mood == "calm");
        }
        else if(newMood == Mood.Sad)
        {
            currentStory = storyManager.Stories.Find(story => story.mood == "sad");
        }
        ShowStory(currentStory);

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoodManager.Instance.RegisterObserver(this);
    }

    void ShowStory(Story story)
    {
        storyTitleText.text = story.title;
        storyDescriptionText.text = story.description;
    }
}
