using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class count : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public int coinCount;

    void Start(){
        coinCount = GlobalControl.Instance.currentMoney;
        coinText.text = coinCount.ToString();
    }

    public void addcoin(){
        coinCount = GlobalControl.Instance.currentMoney;
        coinText.text = coinCount.ToString();
    }
}
