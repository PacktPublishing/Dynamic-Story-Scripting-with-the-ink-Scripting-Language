using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkStoryScript : MonoBehaviour
{
    public TextAsset InkJSONFile;
    public Text SpeakerNameText;
    public Text InkOutputText;
    public Button ButtonPrefab;
    public GameObject DialoguePanel;
    public GameObject OptionsPanel;
    public Text MediaText;
    Story InkStory;

    void Start()
    {
        InkStory = new Story(InkJSONFile.text);
        SpeakerNameText.text = "";
        InkOutputText.text = "";
        MediaText.text = "";
        UpdatePanel();
    }

    void UpdatePanel()
    {
        DestroyChildren(OptionsPanel.transform);
        
        string inkOutput = InkStory.ContinueMaximally();
        if(inkOutput.Contains(":"))
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

        if(InkStory.currentTags.Count > 0)
        {
            MediaText.text = InkStory.currentTags[0];
        }
        else
        {
            MediaText.text = "";
        }

        foreach (Choice choice in InkStory.currentChoices)
        {
            Button choiceButton = Instantiate(ButtonPrefab, OptionsPanel.transform);
            choiceButton.onClick.AddListener(delegate
            {
                InkStory.ChooseChoiceIndex(choice.index);
                UpdatePanel();
            });

            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = choice.text;
        }
    }
    void DestroyChildren(Transform t)
    {
        foreach (Transform child in t)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
