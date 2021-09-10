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
    Story InkStory;

    void Start()
    {
        InkStory = new Story(InkJSONFile.text);
        SpeakerNameText.text = "";
        InkOutputText.text = "";
        UpdatePanel();
    }

    void UpdatePanel()
    {
        DestroyChildren(OptionsPanel.transform);
        InkOutputText.text = InkStory.ContinueMaximally();
        SpeakerNameText.text = InkStory.currentTags[0];

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
