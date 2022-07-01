using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DivideBasket : MonoBehaviour, IDropHandler
{
    public double value;
    public GameObject ValueObj;
    public TMP_Text valueText;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<CatImage>() != null)
            {
                Debug.Log("2");
                CatImage cat = eventData.pointerDrag.GetComponent<CatImage>();
                if (cat.squareCount == null) 
                {
                    cat.squareCount = this.gameObject;
                    cat.collided = true;
                    value += cat.value;
                    SetValueText();
                    return;
                }
                cat.DiVsquareCount = cat.squareCount;
                cat.squareCount = this.gameObject;
                if(cat.squareCount != null && cat.squareCount != cat.DiVsquareCount)
                {
                    cat.DiVsquareCount.GetComponent<DivideBasket>().value -= cat.value;
                    cat.DiVsquareCount.GetComponent<DivideBasket>().SetValueText();
                    cat.collided = true;
                    value += cat.value;
                    SetValueText();
                }
                else if(cat.squareCount == cat.DiVsquareCount)
                {
                    cat.collided = true;
                }
            }
        }
    }

    public void SetValueText()
    {
        valueText.text = value.ToString();
    }
}
