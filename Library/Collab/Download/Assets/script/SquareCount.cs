using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SquareCount : MonoBehaviour, IDropHandler
{
    
    public float Sumvalue;
    public Text valueText;
    private string rmw = " (Circle)";
    private string help ;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("ondrop");
        if (eventData.pointerDrag != null) {
            if(eventData.pointerDrag.GetComponent<DragDrop>() !=null) {
            DragDrop d = eventData.pointerDrag.GetComponent<DragDrop>();

            Debug.Log("This is " + d.value);
            help = d.value.ToString();
            }

            else if(eventData.pointerDrag.GetComponent<DragDrop_NoDup>() !=null) {
            DragDrop_NoDup d = eventData.pointerDrag.GetComponent<DragDrop_NoDup>();

            Debug.Log("This is " + d.value);
            help = d.value.ToString();
            }
           
           
            help = help.Replace(rmw, "");
            Debug.Log("reeeee " + help);
            Sumvalue = Sumvalue + float.Parse(help);
            Sumvalue = Mathf.Round(Sumvalue * 100.0f) * 0.01f;

            valueText.text = Sumvalue.ToString();

        }
    }

    
}
