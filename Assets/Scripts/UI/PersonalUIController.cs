
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PersonalUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI optimizationText, efficiencyText;
    [SerializeField] Button oMinusB, eMinusB, oPlusB, ePlusB;
    public int valueOptimization, valueEfficiency;

    // Start is called before the first frame update
    void Start()
    {
        valueOptimization = 0;
        valueEfficiency = 0;
        optimizationText.text = valueOptimization.ToString();
        efficiencyText.text = valueEfficiency.ToString() + " %";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptimizationMinus()
    {
        if (valueOptimization > 0)
        {
            valueOptimization -= 1;
            optimizationText.text = valueOptimization.ToString();
        }
    }

    public void OptimizationPlus()
    {
        if (valueOptimization < 15)
        {
            valueOptimization += 1;
            optimizationText.text = valueOptimization.ToString();
        }
    }

    public void EfficiencyMinus()
    {
        if (valueEfficiency > 0) 
        {
            valueEfficiency -= 1;
            efficiencyText.text += valueEfficiency.ToString();
        }
    }

    public void EfficiencyPlus()
    {
        if(valueEfficiency < 15)
        {
            valueEfficiency += 1;
            efficiencyText.text += valueEfficiency.ToString() + " %";
        }
    }
}
