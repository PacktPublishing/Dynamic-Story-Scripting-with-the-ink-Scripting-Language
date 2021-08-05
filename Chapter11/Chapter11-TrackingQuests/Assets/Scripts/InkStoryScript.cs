using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class InkStoryScript : MonoBehaviour
{
    public GameObject QuestPanel;
    public Toggle QuestTogglePrefab;
    public Text DialogueText;
    public Button ButtonPrefab;
    public GameObject OptionsPanel;
    public GameObject ProgressPanel;
    public Button ProgressButtonPrefab;
    public static Text StatisticsText;
    static List<Quest> quests;
    void Start()
    {
        quests = new List<Quest>();
        DialogueText.text = "";
        GetFiles();
        CreateQuestToggles();
        ShowStatistics();
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
            ts.StatisticsText = StatisticsText;

            questToggle.group.SetAllTogglesOff();

            q.ObserveVariables((name, value) =>
            {
                UpdateAllQuests(name, value);
            });
        }
    }
    public static void ShowStatistics()
    {
        Dictionary<string, object> vars = new Dictionary<string, object>();

        foreach (Quest q in quests)
        {
            foreach(string s in q.InkStory.variablesState)
            {
                if(!vars.ContainsKey(s) && !q.excludeVariables.Contains(s))
                {
                    vars.Add(s, q.InkStory.variablesState[s]);
                }
            }
        }

        foreach (KeyValuePair<string, object> entry in vars)
        {
            StatisticsText.text += entry.Key + ": " + entry.Value + "\n";
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
    void UpdateAllQuests(string name, object value)
    {
        foreach (Quest q in quests)
        {
            q.UpdateVariable(name, value);
        }
    }
}
