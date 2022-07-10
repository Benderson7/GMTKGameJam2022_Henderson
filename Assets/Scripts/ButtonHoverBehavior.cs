using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverBehavior : MonoBehaviour
{
    void Start()
    {
        ChangeAlpha(0);
    }

    public void Show()
    {
        ChangeAlpha(255);
    }

    public void Hide()
    {
        ChangeAlpha(0);
    }

    private void ChangeAlpha(int value)
    {
        Color color = gameObject.GetComponent<Image>().color;
        color.a = value;
        gameObject.GetComponent<Image>().color = color;
    }
}
