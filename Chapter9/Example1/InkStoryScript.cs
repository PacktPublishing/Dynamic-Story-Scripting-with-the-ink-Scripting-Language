using UnityEngine;
using Ink.Runtime;

public class InkStoryScript : MonoBehaviour
{
    public TextAsset InkJSONFile;
    Story InkStory;

    void Start()
    {
        InkStory = new Story(InkJSONFile.text);
        if (InkStory.variablesState.GlobalVariableExistsWithName("steps"))
        {
            InkStory.ObserveVariable("steps", (variableName, newValue) =>
            {
                Debug.Log(newValue);
            });
        }

        Debug.Log(InkStory.ContinueMaximally());
        InkStory.ChooseChoiceIndex(0);
        Debug.Log(InkStory.ContinueMaximally());
        InkStory.ChooseChoiceIndex(0);
    }
}
