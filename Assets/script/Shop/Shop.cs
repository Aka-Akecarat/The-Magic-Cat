using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject ShopCanvas;
    public GameObject NoMoneyPanel;
    public GameObject MaxHPPanel;
    public TextMeshProUGUI MoneyText;
    public GameManager gameManager;
    public Unit v;

    public Slider hpSlider;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI HealthText;
    void Start()
    {
        gameManager = GameManager.Instance;
        v = gameManager.Player.GetComponent<Unit>();
        var currMoney = v.currentMoney.ToString();
        MoneyText.text = currMoney;
        gameManager.SetHP();

    }
    public bool BuyHealth(int health, int cost)
    {
        if (v.currentMoney - cost < 0)
        {
            Debug.Log("not enought money");
            NoMoneyPanel.SetActive(true);
            return false;
        }
        else if (v.currentHP >=100 && v.currentHP + health > v.maxHP)
        {
            Debug.Log("already max HP");
            MaxHPPanel.SetActive(true);
            return false;
        }
        else
        {   
            v.currentMoney -= cost;
            v.currentHP += health;
            if (v.currentHP >= 100)
            {
                v.currentHP = v.maxHP;
            }
            return true;
        }
    }
    public void closeNoMoney()
    {
        NoMoneyPanel.SetActive(false);
    }
    public void closeMaxHP()
    {
        MaxHPPanel.SetActive(false);
    }
    public void ExitShop()
    {
        ShopCanvas.SetActive(false);
    }
    public void Heal10()
    {
        if (BuyHealth(10,25))
        {
            Debug.Log("Heal 10 HP");
            SavePlayer();
        }
    }
    public void Heal25()
    {
        if (BuyHealth(25, 50))
        {
            Debug.Log("Heal 25 HP");
            SavePlayer();
        }
    }
    public void Heal60()
    {
        if (BuyHealth(60, 75))
        {
            Debug.Log("Heal 60 HP");
            SavePlayer();
        }
    }
    public void Heal80()
    {
        if (BuyHealth(80, 100))
        {
            Debug.Log("Heal 80 HP");
            SavePlayer();
        }
    }
    public void SavePlayer()
    {
        GlobalControl.Instance.currentHP = v.currentHP;
        GlobalControl.Instance.currentMoney = v.currentMoney;
        MoneyText.text = v.currentMoney.ToString();
        gameManager.SetHP();
    }
    
}
