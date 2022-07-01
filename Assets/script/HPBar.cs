using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBar : MonoBehaviour
{
    public Slider hpSlider;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI HPText;

    void Start()
    {
        SetHP();
    }

    public void SetHP()
    {
        hpSlider.value = GlobalControl.Instance.currentHP;
        fill.color = gradient.Evaluate(hpSlider.normalizedValue);
        HPText.text = GlobalControl.Instance.currentHP.ToString();
        HPText.color = gradient.Evaluate(hpSlider.normalizedValue);
    }
}
