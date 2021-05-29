using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class LoadingChoices : MonoBehaviour
{
    public TextAsset InkJSONAsset;


    // Start is called before the first frame update
    void Start()
    {
        Story InkStory = new Story(InkJSONAsset.text);
        Debug.Log(InkStory.ContinueMaximally());
        Choice exampleChoice = InkStory.currentChoices[0];
        Debug.Log(exampleChoice.text);
        InkStory.ChooseChoiceIndex(exampleChoice.index);
        Debug.Log(InkStory.ContinueMaximally());
    }
}
