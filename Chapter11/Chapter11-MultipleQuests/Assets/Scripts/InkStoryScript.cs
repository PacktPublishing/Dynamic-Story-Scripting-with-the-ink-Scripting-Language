using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InkStoryScript : MonoBehaviour
{
    public GameObject QuestPanel;
    public Toggle QuestTogglePrefab;
    public Text DialogueText;
    public Button ButtonPrefab;
    public GameObject OptionsPanel;
    public GameObject ProgressPanel;
    public Button ProgressButtonPrefab;
    List<Quest> quests;
    void Start()
    {
        quests = new List<Quest>();
        DialogueText.text = "";
        GetFiles();
        CreateQuestToggles();
    }

    void CreateQuestToggles()
    {
        foreach(Quest q in quests)
        {
            Toggle questToggle = Instantiate(QuestTogglePrefab, QuestPanel.transform);
            questToggle.group = QuestPanel.GetComponent<ToggleGroup>();
            
            Text questToggleText = questToggle.GetComponentInChildren<Text>();
            questToggleText.text = q.Name;
            
            ToggleScript ts = questToggle.GetComponent<ToggleScript>();
            ts.quest = q;
            ts.DialogueText = DialogueText;
            ts.ButtonPrefab = ButtonPrefab;
            ts.OptionsPanel = OptionsPanel;
            ts.ProgressPanel = ProgressPanel;
            ts.ProgressButtonPrefab = ProgressButtonPrefab;

            questToggle.group.SetAllTogglesOff();
        }
    }

    void GetFiles()
    {
        string inkPath = Application.dataPath + "/Ink/";
        foreach(string file in Directory.GetFiles(inkPath, "*.json"))
        {
            string contents = File.ReadAllText(file);
            quests.Add(new Quest(contents));
        }  
    }
}
