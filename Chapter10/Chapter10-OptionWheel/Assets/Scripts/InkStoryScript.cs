using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class InkStoryScript : MonoBehaviour
{
    public TextAsset InkJSONFile;
    public GameObject DialogueCanvas;
    Button[] DirectionalButtons;
    Story InkStory;
    void Start()
    {
        InkStory = new Story(InkJSONFile.text);
        DirectionalButtons = DialogueCanvas.GetComponentsInChildren<Button>();
        UpdateCanvas();
    }
    void UpdateCanvas()
    {
        RemoveAllListeners();

        if (InkStory.canContinue)
        {
            InkStory.ContinueMaximally();
            int buttonCount = 0;
            foreach(Choice choice in InkStory.currentChoices)
            {
                if(buttonCount < DirectionalButtons.Length)
                {
                    SetButton(DirectionalButtons[buttonCount], choice);
                    buttonCount++;
                }
            }
        }
    }
    void SetButton(Button b, Choice c)
    {
        b.onClick.AddListener(delegate
        {
            InkStory.ChooseChoiceIndex(c.index);
            UpdateCanvas();
        });

        Text choiceText = b.GetComponentInChildren<Text>();
        choiceText.text = c.text;
    }
    void RemoveAllListeners()
    {
        foreach(Button b in DirectionalButtons)
        {
            b.onClick.RemoveAllListeners();
        }
    }
}
