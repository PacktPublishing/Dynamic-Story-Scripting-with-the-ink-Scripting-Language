using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;

public class InkStoryScript : MonoBehaviour
{
    List<Story> Stories;
    
    void Start()
    {
        Stories = new List<Story>();
        GetFiles();
        while(Stories.Count > 0)
        {
            PickRandomStory();
        }
        
    }

    void GetFiles()
    {

        string inkPath = Application.dataPath + "/Ink/";
        foreach (string file in Directory.GetFiles(inkPath, "*.json"))
        {

            string contents = File.ReadAllText(file);
            Stories.Add(new Story(contents));
        }
    }

    void PickRandomStory()
    {
        System.Random rand = new System.Random();
        int index = rand.Next(Stories.Count);
        Story entry = Stories[index];
        Debug.Log(entry.Continue());
        Stories.RemoveAt(index);
    }

}
