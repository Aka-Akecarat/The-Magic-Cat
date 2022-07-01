using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider hpSlider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        SetHP();
    }

    public void SetHP()
    {
        hpSlider.value = GlobalControl.Instance.currentHP;
        fill.color = gradient.Evaluate(hpSlider.normalizedValue);
    }
}
