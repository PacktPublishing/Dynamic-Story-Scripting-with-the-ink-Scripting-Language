using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class TextHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Text textGameObject;
    Color DefaultColor;
    public Color HoverColor;
    void Start()
    {
        textGameObject = gameObject.GetComponent<Text>();
        DefaultColor = textGameObject.color;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        textGameObject.color = HoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textGameObject.color = DefaultColor;
    }
    void OnEnable()
    {
        textGameObject = gameObject.GetComponent<Text>();
        DefaultColor = Color.black;
    }
}