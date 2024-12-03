using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTScanController : MonoBehaviour
{

    public Sprite[] sprites3PL2, spritesAXPD9, spritesAXPDFAT, spritesCORPDFAT, spritesCORT14, spritesSAGPDFAT, spritesSAGT16;
    public int cTScanOption = 0;

    public Image imageReference;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        imageReference.sprite = spritesAXPD9[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCTScan(int _ctScanOption)
    {
        cTScanOption = _ctScanOption;

        if (cTScanOption == 0)
        {
            imageReference.sprite = sprites3PL2[0];
            slider.maxValue = sprites3PL2.Length - 1;
        }
        else if (cTScanOption == 1)
        {
            imageReference.sprite = spritesAXPD9[0];
            slider.maxValue = spritesAXPD9.Length - 1;
        }
        else if (cTScanOption == 2)
        {
            imageReference.sprite = spritesAXPDFAT[0];
            slider.maxValue = spritesAXPDFAT.Length - 1;
        }
        else if (cTScanOption == 3)
        {
            imageReference.sprite = spritesCORPDFAT[0];
            slider.maxValue = spritesCORPDFAT.Length - 1;
        }
        else if (cTScanOption == 4)
        {
            imageReference.sprite = spritesCORT14[0];
            slider.maxValue = spritesCORT14.Length - 1;
        }
        else if (cTScanOption == 5)
        {
            imageReference.sprite = spritesSAGPDFAT[0];
            slider.maxValue = spritesSAGPDFAT.Length - 1;
        }
        else if (cTScanOption == 6)
        {
            imageReference.sprite = spritesSAGT16[0];
            slider.maxValue = spritesSAGT16.Length - 1;
        }
        
    }

   

    public void CTScanImageChanger(float sliderValue)
    {
        if (cTScanOption == 0)
            imageReference.sprite = sprites3PL2[(int)sliderValue];
        else if (cTScanOption == 1)
            imageReference.sprite = spritesAXPD9[(int)sliderValue];
        else if (cTScanOption == 2)
            imageReference.sprite = spritesAXPDFAT[(int)sliderValue];
        else if (cTScanOption == 3)
            imageReference.sprite = spritesCORPDFAT[(int)sliderValue];
        else if (cTScanOption == 4)
            imageReference.sprite = spritesCORT14[(int)sliderValue];
        else if (cTScanOption == 5)
            imageReference.sprite = spritesSAGPDFAT[(int)sliderValue];
        else if (cTScanOption == 6)
            imageReference.sprite = spritesSAGT16[(int)sliderValue];
    }
}
