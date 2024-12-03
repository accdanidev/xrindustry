    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;


public class ButtonSelectionController : MonoBehaviour
{
    public Button[] button;
    bool activated = false;
    int numberOFButton;
        
    public void SelectedButton(int _number)
    {
        if (activated)
        {
            UnSelectColor(button[numberOFButton]);
            numberOFButton = _number;
            SelectedColor(button[numberOFButton]);
        }
        else
        {
            numberOFButton = _number;
            SelectedColor(button[numberOFButton]);
            activated = true;
        }
    }

    void SelectedColor(Button _button)
    {
        ColorBlock colorBlock = _button.colors;
        colorBlock.normalColor = Color.white;
        _button.colors = colorBlock;
    }

    private void UnSelectColor(Button _button)
    {
        print("enter");
        ColorBlock colorBlock = _button.colors;
        Color color = new Color(0.8627450980392157f, 0.8627450980392157f, 0.8627450980392157f);
        colorBlock.normalColor = color;
        _button.colors = colorBlock;
    }
}
