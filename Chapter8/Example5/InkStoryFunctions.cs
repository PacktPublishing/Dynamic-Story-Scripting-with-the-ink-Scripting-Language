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
		    localStory.EvaluateFunction("increase", 1);
	    }
        if(localStory.HasFunction("current"))
	    {
		    string functionOutput;
		    localStory.EvaluateFunction("current", out functionOutput);
		    Debug.Log(functionOutput);
	    }
    }
}
