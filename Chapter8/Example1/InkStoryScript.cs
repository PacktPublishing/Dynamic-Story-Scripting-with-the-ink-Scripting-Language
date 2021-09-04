using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkStoryScript : MonoBehaviour
{
    public TextAsset InkJSONFile;

    void Start()
    {
        Story localStory = new Story(InkJSONFile.text);
        Debug.Log(localStory.variablesState.GetVariableWithName("number_example"));
    }
}
