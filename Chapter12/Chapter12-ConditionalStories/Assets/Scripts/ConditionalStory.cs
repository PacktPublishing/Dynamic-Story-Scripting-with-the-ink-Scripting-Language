using System.Collections.Generic;
using Ink.Runtime;

public class ConditionalStory
{
    public Story InkStory;
    public ConditionalStory(string CompiledInkText)
    {
        InkStory = new Story(CompiledInkText);
    }

    public void ObserveVariables(Story.VariableObserver callback)
    {
        InkStory.ObserveVariables(new List<string>() { "violence", "peace" }, callback);
    }

    public void UpdateVariable(string name, object value)
    {
        if (InkStory.variablesState.GlobalVariableExistsWithName(name))
        {
            if (!InkStory.variablesState[name].Equals(value))
            {
                InkStory.variablesState[name] = value;
            }
        }
    }

    public bool Available()
    {
        bool result = false;

        if(InkStory.HasFunction("check"))
        {
            result = (bool) InkStory.EvaluateFunction("check");
        }

        return result;
    }
}
