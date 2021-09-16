using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System.IO;

public class InkStoryScript : MonoBehaviour
{
    List<Story> Stories;
    public GameObject OptionsPanel;
    public Text SceneDescription;
    public Text StatisticsText;
    public Button ButtonPrefab;
    int violence = 0;
    int peace = 0;
    
    void Start()
    {
        Stories = new List<Story>();
        UpdateStatistics();
        GetFiles();
        PickRandomStory();
    }

    void UpdateStatistics()
    {
        StatisticsText.text = "Violence: " + violence + " | peace: " + peace;
    }
    void UpdateContent(Story InkStory)
    {
        DestroyChildren(OptionsPanel.transform);

        InkStory.ObserveVariables(new List<string>(){ "violence", "peace" }, (variable, value) =>
        {
            switch(variable)
            {
                case "violence":
                    violence += (int) value;
                    break;

                case "peace":
                    peace += (int) value;
                    break;

                default:
                    break;
            }
            
            UpdateStatistics();
        });

        SceneDescription.text = InkStory.ContinueMaximally();

        foreach (Choice choice in InkStory.currentChoices)
        {
            Button choiceButton = Instantiate(ButtonPrefab, OptionsPanel.transform);
            choiceButton.onClick.AddListener(delegate
            {
                InkStory.ChooseChoiceIndex(choice.index);
                InkStory.Continue();
                DestroyChildren(OptionsPanel.transform);
                SceneDescription.text = "";
                PickRandomStory();
            });

            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = choice.text;
        }
    }

    void DestroyChildren(Transform t)
    {
        foreach (Transform child in t)
        {
            Destroy(child.gameObject);
        }
    }

    void GetFiles()
    {
        string inkPath = Application.dataPath + "/Ink/";
        foreach (string file in Directory.GetFiles(inkPath, "*.json"))
        {
            string contents = File.ReadAllText(file);
            Stories.Add(new Story(contents));
        }
    }

    void PickRandomStory()
    {
        if (Stories.Count > 0)
        {
            System.Random rand = new System.Random();
            int index = rand.Next(Stories.Count);
            Story entry = Stories[index];
            Stories.RemoveAt(index);
            UpdateContent(entry);
        }
        else
        {
            SceneDescription.text = "(There are no more stories.)";
        }
        
    }

}
