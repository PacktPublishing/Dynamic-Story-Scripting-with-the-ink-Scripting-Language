using Ink.Runtime;

public class ConditionalStory
{
    public Story InkStory;
    public ConditionalStory(string CompiledInkText)
    {
        InkStory = new Story(CompiledInkText);
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
