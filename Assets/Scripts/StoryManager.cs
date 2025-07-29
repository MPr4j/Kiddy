using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Story
{
    public string title;
    public string description;
    public string mood;
}

[System.Serializable]
public class StoryList
{
    public List<Story> stories;
}

public class StoryManager : MonoBehaviour
{

  
    public List<Story> Stories { get; private set; }

    void Start()
    {
        LoadStories();
    }
    
    void LoadStories()
    {
        TextAsset jsonText = Resources.Load<TextAsset>("Data/data");
        if (jsonText != null)
        {
            string jsonString = "{ \"stories\": " + jsonText.text + "}";
            StoryList storyList = JsonUtility.FromJson<StoryList>(jsonString);
            Stories = storyList.stories;
            Debug.Log("Stories Loaded: " + Stories.Count);
        }
        else
        {
            Debug.LogError("Stories JSON not found!");
        }
    }

  
}
