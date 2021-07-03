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
        if(localStory.variablesState.GlobalVariableExistsWithName("number_example"))
	    {
		    localStory.variablesState["number_example"] = 10;
	    }
	    Debug.Log(localStory.Continue());
    }
}
