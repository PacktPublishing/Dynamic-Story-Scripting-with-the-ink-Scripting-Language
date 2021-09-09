using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class InkStoryScript : MonoBehaviour
{
    public TextAsset InkJSONFile;
    public GameObject OptionsPanel;
    public Text OutputText;
    Button[] DirectionalButtons;
    Story InkStory;
    void Start()
    {
        InkStory = new Story(InkJSONFile.text);
        DirectionalButtons = OptionsPanel.GetComponentsInChildren<Button>();
        OutputText.text = "";
        UpdateCanvas();
    }
    void UpdateCanvas()
    {
        if (InkStory.canContinue)
        {
            OutputText.text = InkStory.ContinueMaximally();

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
            DestroyChildren(OptionsPanel.transform);
            UpdateCanvas();
        });

        Text choiceText = b.GetComponentInChildren<Text>();
        choiceText.text = c.text;
    }
    void DestroyChildren(Transform t)
    {
        foreach (Transform child in t)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
