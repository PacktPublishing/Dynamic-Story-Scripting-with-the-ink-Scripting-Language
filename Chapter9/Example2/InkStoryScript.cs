using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class InkStoryScript : MonoBehaviour
{
    public TextAsset InkJSONFile;
    public Button ButtonStep;
    Story InkStory;
    float time;
    int seconds;

    void Start()
    {
        InkStory = new Story(InkJSONFile.text);
        if (InkStory.variablesState.GlobalVariableExistsWithName("steps"))
        {
            InkStory.ObserveVariable("steps", (variableName, newValue) =>
            {
                if((int) newValue == 3)
                {
                    Debug.Log("Journey took " + seconds + " seconds.");
                    Destroy(ButtonStep.gameObject);
                }
            });
        }
        ButtonStep.onClick.AddListener(TakeStep);
    }

    void Update()
    {
	    time += Time.deltaTime;
	    seconds = (int) time % 60;
    }

    public void TakeStep()
    {
	    InkStory.ContinueMaximally();
	    InkStory.ChooseChoiceIndex(0);
    }
}
