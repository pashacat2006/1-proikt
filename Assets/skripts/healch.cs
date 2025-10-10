using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healch : MonoBehaviour
{
    public  Image Heal;
    public float value;
    public  void SetHealthBarValue(float value)
    {
        Heal.fillAmount = value;
    }
    public  float GetHealthBarValue()
    {
        return Heal.fillAmount;    
    }
    public void Health()
    {
        SetHealthBarValue(GetHealthBarValue() - 0.03f);
    }
}