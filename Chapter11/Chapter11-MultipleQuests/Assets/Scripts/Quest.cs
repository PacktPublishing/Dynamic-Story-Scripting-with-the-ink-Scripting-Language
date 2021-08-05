using Ink.Runtime;

public class Quest
{
    public Story InkStory;
    public string Name;
    public string Description;
    public bool End;

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
    public void Progress()
    {
        InkStory.ChoosePathString("progress");
    }
}
