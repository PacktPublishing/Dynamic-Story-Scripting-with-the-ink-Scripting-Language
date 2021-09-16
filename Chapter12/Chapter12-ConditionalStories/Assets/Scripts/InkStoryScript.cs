using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkStoryScript : MonoBehaviour
{
    List<ConditionalStory> Stories;
    public Text StatisticsText;
    public Text SceneDescription;
    public GameObject OptionsPanel;
    public Button ButtonPrefab;
    int violence = 0;
    int peace = 0;

    void Start()
    {
        Stories = new List<ConditionalStory>();
        GetFiles();
        UpdateStatistics();
        SelectStories();
    }

    void GetFiles()
    {
        string inkPath = Application.dataPath + "/Ink/";
        foreach (string file in Directory.GetFiles(inkPath, "*.json"))
        {
            string contents = File.ReadAllText(file);
            Stories.Add(new ConditionalStory(contents));
        }
    }

    void UpdateVariables()
    {
        foreach(ConditionalStory s in Stories)
        {
            //s.InkStory.variablesState["violence"] = violence;
            //s.InkStory.variablesState["peace"] = peace;
        }
    }

    void SelectStories()
    {
        List<ConditionalStory> selection = Stories.FindAll(e => e.Available());

        if (selection.Count > 0)
        {
            System.Random rand = new System.Random();
            int index = rand.Next(selection.Count);
            Story entry = selection[index].InkStory;
            Stories.RemoveAt(index);
            UpdateContent(entry);
        }
        else
        {
            SceneDescription.text = "(There are no more stories.)";
        }
    }

    void UpdateStatistics()
    {
        StatisticsText.text = "Violence: " + violence + " | peace: " + peace;
    }

    void UpdateContent(Story InkStory)
    {
        DestroyChildren(OptionsPanel.transform);

        InkStory.ObserveVariables(new List<string>() { "violence", "peace" }, (variable, value) =>
        {
            switch (variable)
            {
                case "violence":
                    violence += (int)value;
                    UpdateVariables();
                    break;

                case "peace":
                    peace += (int)value;
                    UpdateVariables();
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
                SelectStories();
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

}
