using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject ShopCanvas;
    public TextMeshProUGUI MoneyText;
    public GameManager gameManager;
    public Unit v;

    public Slider hpSlider;
    public Gradient gradient;
    public Image fill;
    void Start()
    {
        gameManager = GameManager.Instance;
        v = gameManager.Player.GetComponent<Unit>();
        var currMoney = v.currentMoney.ToString();
        MoneyText.text = currMoney;
        SetHP();

    }
    public void ExitShop()
    {
        ShopCanvas.SetActive(false);
    }
    public void Heal10()
    {
        v.currentHP += 10;
        v.currentMoney -= 25;
        Debug.Log("Heal 10 HP");
        SavePlayer();
    }
    public void Heal25()
    {
        v.currentHP += 25;
        v.currentMoney -= 50;
        Debug.Log("Heal 25 HP");
        SavePlayer();
    }
    public void Heal60()
    {
        v.currentHP += 60;
        v.currentMoney -= 75;
        Debug.Log("Heal 60 HP");
        SavePlayer();
    }
    public void Heal80()
    {
        v.currentHP += 80;
        v.currentMoney -= 100;
        Debug.Log("Heal 80 HP");
        SavePlayer();
    }

    public void SavePlayer()
    {
        GlobalControl.Instance.currentHP = v.currentHP;
        GlobalControl.Instance.currentMoney = v.currentMoney;
        var x = GlobalControl.Instance.currentMoney.ToString();
        MoneyText.text = x;
        SetHP();
    }

    public void SetHP()
    {
        hpSlider.value = GlobalControl.Instance.currentHP;
        fill.color = gradient.Evaluate(hpSlider.normalizedValue);
    }
}
