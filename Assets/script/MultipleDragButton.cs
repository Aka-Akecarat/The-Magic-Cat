using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MultipleDragButton : MonoBehaviour
{
    public Busket busket;
    public Text MutliplyCatText;
    public Button buttonX1;
    public Button buttonX10;
    public Button buttonX100;

    private void Start()
    {
        buttonX1.interactable = false;
        if (MutliplyCatText != null)
        {
            MutliplyCatText.text = "X1";
        }
    }
    public void X1() 
    {
        buttonX1.interactable = false;
        buttonX10.interactable = true;
        buttonX100.interactable = true;
        busket.MultipleDragValue = 1;
        if(MutliplyCatText != null)
        {
            MutliplyCatText.text = "X1";
        }
    }
    public void X10()
    {
        buttonX1.interactable = true;
        buttonX10.interactable = false;
        buttonX100.interactable = true;
        busket.MultipleDragValue = 10;
        if (MutliplyCatText != null)
        {
            MutliplyCatText.text = "X10";
        }
    }
    public void X100()
    {
        buttonX1.interactable = true;
        buttonX10.interactable = true;
        buttonX100.interactable = false;
        busket.MultipleDragValue = 100;
        if (MutliplyCatText != null)
        {
            MutliplyCatText.text = "X100";
        }
    }
}
