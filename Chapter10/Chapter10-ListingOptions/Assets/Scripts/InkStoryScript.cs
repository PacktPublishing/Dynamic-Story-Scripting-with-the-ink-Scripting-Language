using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
public class InkStoryScript : MonoBehaviour
{
    public TextAsset InkJSONFile;
    public Button DialogueOptionButton;
    public Text InkOutputText;
    public GameObject ContentGameObject;
    Story InkStory;

    void Start()
    {
        InkStory = new Story(InkJSONFile.text);
        UpdateContent();
    }

    void UpdateContent()
    {
        DestroyChildren(ContentGameObject.transform);
        InkOutputText.text = InkStory.ContinueMaximally();

        foreach (Choice choice in InkStory.currentChoices)
        {
            Button choiceButton = Instantiate(DialogueOptionButton, ContentGameObject.transform);
            choiceButton.onClick.AddListener(delegate
            {
                InkStory.ChooseChoiceIndex(choice.index);
                UpdateContent();
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
