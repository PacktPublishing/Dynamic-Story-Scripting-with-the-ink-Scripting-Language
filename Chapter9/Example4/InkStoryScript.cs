using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class InkStoryScript : MonoBehaviour
{
    public TextAsset InkJSONFile;
    Story InkStory;
    public Canvas InkTextAndOptionsCanvas;
    public Button PrefabButton;
    public Text PrefabText;
    public Text VariableStatusText;

    void Start()
    {
        InkStory = new Story(InkJSONFile.text);
        List<string> variableNames = new List<string>();
        
        foreach(string inkVariable in InkStory.variablesState)
        {
            variableNames.Add(inkVariable);
        }
        
        InkStory.ObserveVariables(variableNames, (variableName, newValue) =>
        {
            VariableStatusText.text = "The variable " + variableName + " changed to the value " + newValue;
        });

        VariableStatusText.text = "";
        UpdateCanvas();
    }

    void UpdateCanvas()
    {
        DestoryChildren(InkTextAndOptionsCanvas.transform);

        Text inkStoryText = Instantiate(PrefabText, InkTextAndOptionsCanvas.transform);
        inkStoryText.text = InkStory.ContinueMaximally();

        foreach (Choice choice in InkStory.currentChoices)
        {
            Button choiceButton = Instantiate(PrefabButton, InkTextAndOptionsCanvas.transform);
            choiceButton.onClick.AddListener(delegate
            {
                InkStory.ChooseChoiceIndex(choice.index);
                UpdateCanvas();
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
}
