using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkStory : MonoBehaviour
{
    public TextAsset InkJSONAsset;
    public GameObject prefabButton;

    private Story inkStory;
    private Text currentLinesText;

    void Start()
    {
        inkStory = new Story(InkJSONAsset.text);
        currentLinesText = GetComponentInChildren<Text>();
        LoadTextAndWeave();
    }
    void LoadTextAndWeave()
    {
        if (inkStory.canContinue)
        {
            currentLinesText.text = inkStory.ContinueMaximally();

            foreach (Choice c in inkStory.currentChoices)
            {
                GameObject cloneButtonGameObject = Instantiate(prefabButton, this.transform);

                Button cloneButtonButton = cloneButtonGameObject.GetComponent<Button>();
                cloneButtonButton.onClick.AddListener(delegate
                {
                    inkStory.ChooseChoiceIndex(c.index);
                    DestoryButtonChildren();
                    LoadTextAndWeave();
                });

                Text cloneButtonText = cloneButtonButton.GetComponentInChildren<Text>();
                cloneButtonText.text = c.text;
            }
        }
    }
    void DestoryButtonChildren()
    {
        foreach (Transform child in transform)
        {
            if(child.tag == "ButtonChoice")
            {
                GameObject.Destroy(child.gameObject);
            }
           
        }
    }
}
