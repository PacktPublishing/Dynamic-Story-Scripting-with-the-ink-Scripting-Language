using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class Quest
{
    public Story InkStory;
    public string Name;
    public string Description;
    public bool End;
    public List<string> excludeVariables = new List<string>(){ "step", "steps", "name", "end" };

    public Quest(string text)
    {
        InkStory = new Story(text);
        Name = (string)InkStory.variablesState["name"];
        End = (bool)InkStory.variablesState["end"];

        InkStory.ObserveVariable("end", delegate
        {
            End = (bool)InkStory.variablesState["end"];
        });
    }
    public void ObserveVariables(Story.VariableObserver callback)
    {
        List<string> vars = new List<string>();

        foreach (string n in InkStory.variablesState)
        {
            if(!excludeVariables.Contains(n))
            {
                vars.Add(n);
            }
        }

        InkStory.ObserveVariables(vars, callback);
    }

    public void UpdateVariable(string name, object value)
    {
        if(InkStory.variablesState.GlobalVariableExistsWithName(name))
        {
            if (!InkStory.variablesState[name].Equals(value))
            {
                InkStory.variablesState[name] = value;
            }
        }
    }
    public void Progress()
    {
        InkStory.ChoosePathString("progress");
    }
}
