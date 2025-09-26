using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healch : MonoBehaviour
{
    public static Image Heal;
    float value;
    private void Start()
    {
        Heal = GetComponent<Image>();
    }
    public static void SetHealthBarValue(float value)
    {
        Heal.fillAmount = value;
    }
    public static float GetHealthBarValue()
    {
        return Heal.fillAmount;    
    }
    public void Health()
    {
        SetHealthBarValue(GetHealthBarValue() - 0.03f);
    }
}