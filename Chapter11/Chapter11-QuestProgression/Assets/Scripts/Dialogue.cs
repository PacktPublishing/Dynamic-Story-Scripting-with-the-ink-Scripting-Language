using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class Dialogue : MonoBehaviour
{
    public Text DialogueText;
    public Button ButtonPrefab;
    public GameObject OptionsPanel;
    private Story InkStory;
    public Dialogue(ref Story story)
    {
        InkStory = story;
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
}
