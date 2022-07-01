using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint4_2 : MonoBehaviour
{
    public AnswerScript4_2[] ChoiceButton;
    public int cost = 50;

    public void needHelp()
    {
        if (GlobalControl.Instance.currentMoney >= cost)
        {
            GlobalControl.Instance.currentMoney -= cost;
            var x = GlobalControl.Instance.currentMoney.ToString();
            GameObject.Find("BattleSystem").GetComponent<BattleSystem>().MoneyText.text = x;
        }
        else { return; }
        List<GameObject> falseButton = new List<GameObject>();
        for (int i = 0; i < ChoiceButton.Length; i++)
        {
            if (ChoiceButton[i].isCorrect == false)
            {
                //Debug.Log(ChoiceButton[i].gameObject.name);
                falseButton.Add(ChoiceButton[i].gameObject);
            }
	    }
        for (int i = 0; i < 2; i++)
        {
            var x = Random.Range(0, falseButton.Count - 1);
            falseButton[x].GetComponent<Button>().interactable = false;
            falseButton.RemoveAt(x);
            Debug.Log(falseButton[x].name);
        }

        this.gameObject.GetComponent<Button>().interactable = false;
    }
}
