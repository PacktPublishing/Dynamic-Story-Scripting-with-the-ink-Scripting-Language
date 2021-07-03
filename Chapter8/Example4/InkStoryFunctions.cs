using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkStoryFunctions : MonoBehaviour
{
    public TextAsset InkJSONFile;

    void Start()
    {
        Story localStory = new Story(InkJSONFile.text);
        if(localStory.HasFunction("increase"))
        {
            // Use function
        }
    }
}
