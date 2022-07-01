using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SquareCount : MonoBehaviour, IDropHandler
{
    
    public double SumValue = 0.00d;
    public double acceptValue = 0.00d;
    public Text valueText;
    private string rmw = " (Circle)";
    private string help ;
    public GameObject[] CatPic;
    public GameObject[] OutsideCatPic;
    public int count;
    public int outsideCount;
    public GameObject swapbutton;

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
                if (eventData.pointerDrag.GetComponent<DragDrop_NoDup>().value != acceptValue) 
                {
                    return;
                }
            DragDrop_NoDup d = eventData.pointerDrag.GetComponent<DragDrop_NoDup>();
                
            Debug.Log("This is " + d.value);
            help = d.value.ToString();
                if (SumValue < acceptValue*10)
                {
                    if (count < CatPic.Length)
                    {
                        CatPic[count].SetActive(true);
                    }
                }
                count += 1;
            }
            else if (eventData.pointerDrag.GetComponent<CatImage>() != null)
            {
                if (eventData.pointerDrag.GetComponent<CatImage>().value != acceptValue)
                {
                    eventData.pointerDrag.GetComponent<CatImage>().GoBack();
                    return;
                }
                CatImage d = eventData.pointerDrag.GetComponent<CatImage>();

                Debug.Log("This is " + d.value);
                help = "0";
                //d.transform.position = this.transform.position;
                d.collided = true;
                return;
            }

            else if (eventData.pointerDrag.GetComponent<CatImage_Minus>() != null)
            {
                CatImage_Minus d = eventData.pointerDrag.GetComponent<CatImage_Minus>();
                Debug.Log("This is " + d.value);
                if (eventData.pointerDrag.GetComponent<CatImage_Minus>().value != acceptValue)//wrong box
                {
                    if (eventData.pointerDrag.GetComponent<CatImage_Minus>().fromOutside != true)
                    {
                        eventData.pointerDrag.GetComponent<CatImage_Minus>().minus();
                    } 
                    if(eventData.pointerDrag.GetComponent<CatImage_Minus>().value / 10 == acceptValue)
                    {
                        foreach (GameObject catpic in CatPic)
                        {
                            catpic.SetActive(true);
                        }
                        SumValue += eventData.pointerDrag.GetComponent<CatImage_Minus>().value;
                        count += 10;
                        setText();
                        Debug.Log("value / 10 = " + acceptValue);
                    }
                    if (eventData.pointerDrag.GetComponent<CatImage_Minus>().value / 100 == acceptValue)
                    {
                        foreach (GameObject catpic in CatPic)
                        {
                            catpic.SetActive(true);
                        }
                        
                        SumValue += eventData.pointerDrag.GetComponent<CatImage_Minus>().value;
                        count += 100;
                        setText();
                        Debug.Log("value / 100 = " + acceptValue);
                    }
                    eventData.pointerDrag.SetActive(false);
                    eventData.pointerDrag.GetComponent<CatImage_Minus>().SetBack();
                    eventData.pointerDrag.GetComponent<CatImage_Minus>().GoBack();
                    CheckSwapButton();
                    return; 
                }

                if (eventData.pointerDrag.GetComponent<CatImage_Minus>().fromOutside != true)//inside
                {
                    help = "0";
                }
                else//outside
                {
                    //eventData.pointerDrag.GetComponent<CatImage_Minus>().fromOutside = false;
                    help = d.value.ToString();
                    eventData.pointerDrag.GetComponent<CatImage_Minus>().GoBack();
                    if (SumValue < 10)
                    {
                        if (count < CatPic.Length)
                        {
                            CatPic[count].SetActive(true);
                            count += 1;
                        }
                        if (outsideCount > 0)
                        {
                            outsideCount -= 1;
                            OutsideCatPic[outsideCount].SetActive(false);
                            
                        }
                    }
                    eventData.pointerDrag.GetComponent<CatImage_Minus>().SetBack();
                }
                //d.transform.position = this.transform.position;
                d.collided = true;
            }


            help = help.Replace(rmw, "");
            Debug.Log("reeeee " + help);
            SumValue = SumValue + double.Parse(help);
            //Sumvalue = Mathf.Round((float)(Sumvalue * 100.0f)) * 0.01f;
            setText();
            CheckSwapButton();
        }
    }

    public void setText()
    {
        valueText.text = SumValue.ToString();
    }
    public void DisableRaycast()
    {
        for(int i=0; i<CatPic.Length; i++)
        {
            CatPic[i].GetComponent<CatImage>().canvasGroup.blocksRaycasts = false;
        }
    }
    public void EnableRaycast()
    {
        for (int i = 0; i < CatPic.Length; i++)
        {
            CatPic[i].GetComponent<CatImage>().canvasGroup.blocksRaycasts = false;
        }
    }
    public void CheckSwapButton()
    {
        if (swapbutton == null)
        {
            return;
        }
        //if (SumValue >= acceptValue * 10)
        if (count >= 10)
        {
            Debug.Log("true");
            swapbutton.SetActive(true);
        }
        else if (SumValue < acceptValue * 10)
        {
            Debug.Log("false");
            Debug.Log(SumValue + "///" + acceptValue * 10 + "///" + swapbutton);
            swapbutton.SetActive(false);
        }
    }
}
