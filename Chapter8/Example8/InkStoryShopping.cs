using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class InkStoryShopping : MonoBehaviour
{
    public TextAsset InkJSONFile;
    public Text TextStatus;
    private Story inkStory;

    void Start()
    {
        inkStory = new Story(InkJSONFile.text);
	   UpdateText();

    }
    public void UpdateText()
    {
        if (inkStory.HasFunction("status"))
        {
            string inkStoryStatusString;
            inkStory.EvaluateFunction("status", out inkStoryStatusString);
            TextStatus.text = inkStoryStatusString;
        }
    }
   public void Buy()
    {
        if (inkStory.HasFunction("buy"))
        {
            inkStory.EvaluateFunction("buy", 10);
        }
        UpdateText();
    }
    public void Sell()
    {
        if (inkStory.HasFunction("sell"))
        {
            inkStory.EvaluateFunction("sell", 10);
        }
        UpdateText();
    }
}
