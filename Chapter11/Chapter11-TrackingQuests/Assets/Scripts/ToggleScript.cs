using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public Quest quest;
    public Text DialogueText;
    public Button ButtonPrefab;
    public GameObject OptionsPanel;
    public GameObject ProgressPanel;
    public Button ProgressButtonPrefab;
    public Text StatisticsText;
    Dialogue dialogue;

    void Start()
    {
        dialogue = gameObject.AddComponent<Dialogue>();
        dialogue.quest = quest;
        dialogue.DialogueText = DialogueText;
        dialogue.ButtonPrefab = ButtonPrefab;
        dialogue.OptionsPanel = OptionsPanel;

        Button ProgressButton = Instantiate(ProgressButtonPrefab, ProgressPanel.transform);
        ProgressButton.onClick.AddListener(delegate
        {
            dialogue.quest.Progress();
            dialogue.UpdateContent();
            ProgressButton.gameObject.SetActive(false);
            gameObject.GetComponent<Toggle>().isOn = false;
        });
        ProgressButton.gameObject.SetActive(false);

        Toggle toggleComponent = GetComponent<Toggle>();
        toggleComponent.onValueChanged.AddListener(delegate 
        {
            if(toggleComponent.isOn)
            {
                dialogue.enabled = true;

                if(!quest.InkStory.canContinue && !quest.End && quest.InkStory.currentChoices.Count == 0)
                {
                    ProgressButton.gameObject.SetActive(true);
                }

                dialogue.UpdateContent();
            }
            else
            {
                dialogue.enabled = false;
                ProgressButton.gameObject.SetActive(false);
                dialogue.DestoryChildren();
            }       
        });
    }
    void Update()
    {
        if(quest.End)
        {
            gameObject.SetActive(false);
            dialogue.DestoryChildren();
        }    
    }
}
