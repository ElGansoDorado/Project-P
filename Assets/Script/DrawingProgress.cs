using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DrawingProgress : MonoBehaviour
{
    public Image EnergiImage;
    public Image ProgressImage;

    private void Start()
    {
        EnergiImage.fillAmount = 0f;
        ProgressImage.fillAmount = 0f;
    }

    public void EnergiDrawingPlus(float value)
    {   
        EnergiImage.fillAmount += value;
    }

    public void EnergiDrawingMinus(float value)
    {
        EnergiImage.fillAmount -= value;
    }

    public void BarDrawing(float value)
    {
        ProgressImage.fillAmount += value;
        if (ProgressImage.fillAmount >= 1.0f) ProgressImage.fillAmount = 0f;
    }
}
