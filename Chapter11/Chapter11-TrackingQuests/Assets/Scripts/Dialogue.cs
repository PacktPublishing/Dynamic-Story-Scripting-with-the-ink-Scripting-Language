using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class Dialogue : MonoBehaviour
{
    public Text DialogueText;
    public Button ButtonPrefab;
    public GameObject OptionsPanel;
    public Quest quest;
    string lastDialogue;

    public void UpdateContent()
    {
        DestoryChildren();
        
        if(quest.InkStory.canContinue)
        {
            DialogueText.text = quest.InkStory.ContinueMaximally();
            lastDialogue = DialogueText.text;
        }
        else
        {
            DialogueText.text = lastDialogue;
        }

        foreach (Choice choice in quest.InkStory.currentChoices)
        {
            Button choiceButton = Instantiate(ButtonPrefab, OptionsPanel.transform);
            choiceButton.onClick.AddListener(delegate
            {
                quest.InkStory.ChooseChoiceIndex(choice.index);
                UpdateContent();
            });

            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = choice.text;
        }

        InkStoryScript.ShowStatistics();
    }

    public void DestoryChildren()
    {
        foreach (Transform child in OptionsPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
