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

    void SelectStories()
    {
        foreach (ConditionalStory cs in Stories)
        {
            cs.UpdateVariable("violence", violence);
            cs.UpdateVariable("peace", peace);
        }

        List<ConditionalStory> selection = Stories.FindAll(e => e.Available());

        if (selection.Count > 0)
        {
            System.Random rand = new System.Random();
            int index = rand.Next(selection.Count);
            ConditionalStory entry = selection[index];
            Stories.Remove(entry);
            UpdateContent(entry);
        }
        else
        {
            SceneDescription.text = "(There are no more stories.)";
            StatisticsText.text = "";
        }
    }

    void UpdateStatistics()
    {
        StatisticsText.text = "Violence: " + violence + " | peace: " + peace;
    }

    void UpdateContent(ConditionalStory cs)
    {
        DestroyChildren(OptionsPanel.transform);

        cs.ObserveVariables((name, value) =>
        {
            switch(name)
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

        SceneDescription.text = cs.InkStory.ContinueMaximally();

        foreach (Choice choice in cs.InkStory.currentChoices)
        {
            Button choiceButton = Instantiate(ButtonPrefab, OptionsPanel.transform);
            choiceButton.onClick.AddListener(delegate
            {
                cs.InkStory.ChooseChoiceIndex(choice.index);
                cs.InkStory.ContinueMaximally();
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
