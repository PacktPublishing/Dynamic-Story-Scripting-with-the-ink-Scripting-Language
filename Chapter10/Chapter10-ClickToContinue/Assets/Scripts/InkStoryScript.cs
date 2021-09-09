using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class InkStoryScript : MonoBehaviour
{
    public TextAsset InkJSONFile;
    public Text SpeakerNameText;
    public Text InkOutputText;
    public GameObject DialoguePanel;
    Story InkStory;

    void Start()
    {
        InkStory = new Story(InkJSONFile.text);
        UpdatePanel();
    }

    void UpdatePanel()
    {
        SpeakerNameText.text = "";
        InkOutputText.text = "";

        string inkOutput = "";

        if (InkStory.canContinue)
        {
            inkOutput = InkStory.ContinueMaximally();
        }

        if (inkOutput.Contains(":"))
        {
            string[] splitInkOutput = inkOutput.Split(':');
            splitInkOutput[0] = splitInkOutput[0].TrimEnd(':');
            SpeakerNameText.text = splitInkOutput[0];
            InkOutputText.text = splitInkOutput[1];
        }
        else
        {
            SpeakerNameText.text = "";
            InkOutputText.text = inkOutput;
        }
    }
    public void ProgressDialogue()
    {
        if(InkStory.currentChoices.Count > 0)
        {
            InkStory.ChooseChoiceIndex(0);
        }
        UpdatePanel();
    }
}
