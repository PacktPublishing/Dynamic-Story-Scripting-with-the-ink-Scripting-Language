using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Ink.Runtime;

public class InkStoryScript : MonoBehaviour
{
    List<ConditionalStory> Stories;
    void Start()
    {
        Stories = new List<ConditionalStory>();
        GetFiles();
        SelectStories();
    }

    void GetFiles()
    {

        string inkPath = Application.dataPath + "/Ink/";
        foreach (string file in Directory.GetFiles(inkPath, "*.json"))
        {
            string contents = File.ReadAllText(file);
            Stories.Add(new ConditionalStory(contents));
        }
    }

    void SelectStories()
    {
        List<ConditionalStory> selection = Stories.FindAll(e => e.Available());
        foreach(ConditionalStory cs in selection)
        {
            Debug.Log(cs.InkStory.Continue());
        }
    }
}
