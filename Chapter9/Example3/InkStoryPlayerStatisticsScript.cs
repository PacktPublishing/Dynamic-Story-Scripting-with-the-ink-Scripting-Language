using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkStoryScript : MonoBehaviour
{
    public TextAsset InkJSONFile;
    Story InkStory;

    void Start()
    {
        InkStory = new Story(InkJSONFile.text);
        
        List<string> variableNames = new List<string>();
        variableNames.Add("mental_health");
        variableNames.Add("physical_health");
        
        InkStory.ObserveVariables(variableNames, (variableName, newValue) =>
        {
            Debug.Log("The variable " + variableName + " changed to the value " + newValue);
        });

        ProgressStory();
    }

    void ProgressStory()
    {
	    InkStory.ContinueMaximally();
	    InkStory.ChooseChoiceIndex(0);
	    InkStory.ContinueMaximally();
    }

}
