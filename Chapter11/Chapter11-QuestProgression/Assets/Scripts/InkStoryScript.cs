using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkStoryScript : MonoBehaviour
{
    public TextAsset InkJSONFile;
    public Text DialogueText;
    public Button ButtonPrefab;
    public GameObject OptionsPanel;
    public Button ProgressButton;
    private Story InkStory;
    private void Start()
    {
        InkStory = new Story(InkJSONFile.text);
        InkStory.ObserveVariable("end", delegate
        {
            ProgressButton.gameObject.SetActive(false);
        });
        FlipProgress();
        UpdateContent();
    }
    void UpdateContent()
    {
        DestoryChildren(OptionsPanel.transform);
        DialogueText.text = InkStory.ContinueMaximally();

        foreach (Choice choice in InkStory.currentChoices)
        {
            Button choiceButton = Instantiate(ButtonPrefab, OptionsPanel.transform);
            choiceButton.onClick.AddListener(delegate
            {
                InkStory.ChooseChoiceIndex(choice.index);
                FlipProgress();
                UpdateContent();
            });

            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = choice.text;
        }
    }
    void DestoryChildren(Transform t)
    {
        foreach (Transform child in t)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    public void Progress()
    {
        InkStory.ChoosePathString("progress");
        FlipProgress();
        UpdateContent();
    }
    void FlipProgress()
    {
        ProgressButton.gameObject.SetActive(!ProgressButton.gameObject.activeSelf);
    }
}
