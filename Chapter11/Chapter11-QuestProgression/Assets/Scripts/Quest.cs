using Ink.Runtime;

public class Quest
{
    public string Name;
    public string Description;
    public bool Enabled = false;
    private Story InkStory;
    public Quest(string text)
    {
        InkStory = new Story(text);
        Name = (string) InkStory.variablesState["name"];
        Description = (string) InkStory.variablesState["description"];
    }
    public string GetDialogue()
    {
        string status = "";

        if(InkStory.canContinue)
        {
            status = InkStory.ContinueMaximally();
        }

        return status;
    }
    public void Continue()
    {
        if(InkStory.canContinue && InkStory.currentChoices.Count > 1)
        {
            InkStory.ChooseChoiceIndex(0);
        }
    }
    
}
