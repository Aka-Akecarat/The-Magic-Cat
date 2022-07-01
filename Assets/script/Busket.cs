using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Busket : MonoBehaviour, IDropHandler
{
    public GameObject[] CatPic1;
    public GameObject[] CatPic01;
    public GameObject[] CatPic001;
    public int CatPic1Count = 0;
    public int CatPic01Count = 0;
    public int CatPic001Count = 0;
    public GameObject MM;//MultiplyManager
    public int MultipleDragValue = 1;
    public double value;
    public Text valueText;

    public void Awake()
    {
        //value = MM.GetComponent<MultiplyManager>().value;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("ondrop");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragDrop_NoDup>() != null)
            {
                DragDrop_NoDup d = eventData.pointerDrag.GetComponent<DragDrop_NoDup>();
                if (d.value == 1)
                {
                    int OldCatCount = CatPic1Count;
                    CatPic1Count += MultipleDragValue;
                    for (int i = OldCatCount; i < CatPic1Count; i++)
                    {
                        if (i < CatPic1.Length)
                        {
                            CatPic1[i].SetActive(true);
                        } 
                    }

                }
                if (d.value == 0.1)
                {
                    int OldCatCount = CatPic01Count;
                    CatPic01Count += MultipleDragValue;
                    for (int i = OldCatCount; i < CatPic01Count; i++)
                    {
                        if (i < CatPic01.Length - 1)
                        {
                            CatPic01[i].SetActive(true);
                        }
                    }
                }
                if (d.value == 0.01)
                {
                    int OldCatCount = CatPic001Count;
                    CatPic001Count += MultipleDragValue;
                    for (int i = OldCatCount; i < CatPic001Count; i++)
                    {
                        if (i < CatPic001.Length - 1)
                        {
                            CatPic001[i].SetActive(true);
                        }
                    }
                }
                value += d.value*MultipleDragValue;
                value = System.Math.Round(value, 2);
                if (valueText != null)
                {
                    setText();
                }
            }

            else if (eventData.pointerDrag.GetComponent<CatImage>() != null)
            {
                eventData.pointerDrag.GetComponent<CatImage>().collided = true;
            }
            else if (eventData.pointerDrag.GetComponent<CatGroup>() != null)
            {
                CatGroup cat = eventData.pointerDrag.GetComponent<CatGroup>();
                Debug.Log(cat.value);
                cat.collided = true;
            }
            else if (eventData.pointerDrag.GetComponent<InsideCatGroup>() != null)
            {
                InsideCatGroup cat = eventData.pointerDrag.GetComponent<InsideCatGroup>();
                Debug.Log(cat.value);
                cat.collided = true;
            }
        }
    }
    public void setText()
    {
        if (valueText != null)
        {
            valueText.text = value.ToString();
        }
    }
}
