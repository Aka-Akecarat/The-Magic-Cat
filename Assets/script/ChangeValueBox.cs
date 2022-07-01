using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeValueBox : MonoBehaviour, IDropHandler
{
    public double value;
    public int count1;
    public int count01;
    public int count001;
    public Button SplitButton;
    public Button SumButton;
    public int posPoint = 0;
    public List<PositionList> positionLists = new List<PositionList>();
    public List<GameObject> CatGO1 = new List<GameObject>();
    public List<GameObject> CatGO01 = new List<GameObject>();
    public List<GameObject> CatGO001 = new List<GameObject>();
    public CatImage cat1;
    public CatImage cat01;
    public CatImage cat001;
    void Start()
    {
        SplitButton.interactable = false;
        SumButton.interactable = false;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<CatImage>() != null)
            {
                var cat = eventData.pointerDrag.GetComponent<CatImage>();
                cat.collided = true;
                if (cat.insideChangeValueBox == false)
                {
                    cat.insideChangeValueBox = true;
                    cat.squareCount = this.gameObject;
                    value += cat.value;
                    value = System.Math.Round(value, 2);
                    if (cat.value == 1)
                    {
                        count1 += 1;
                        CatGO1.Add(cat.gameObject);
                        SplitButton.interactable = true;
                    }
                    else if (cat.value == 0.1)
                    {
                        count01 += 1;
                        CatGO01.Add(cat.gameObject);
                        SplitButton.interactable = true;
                    }
                    else if (cat.value == 0.01)
                    {
                        count001 += 1;
                        CatGO001.Add(cat.gameObject);
                    }
                }
                else
                {
                    return;
                }
            }

            if (count01 >= 10 || count001 >= 10)
            {
                SumButton.interactable = true;
            }
        }
    }

    public void Split()
    {
        if (count1 >= 1 && value >= 1)
        {
            for (int i = 0; i < 10; i++)
            {
                CatImage clone = Instantiate(cat01, positionLists[posPoint].Position[i].position, transform.rotation);
                GameObject CatGO = GameObject.Find("CatImage");
                clone.transform.SetParent(CatGO.transform);
                clone.transform.localScale = new Vector3(1, 1, 1);
                clone.canvasGroup = CatGO.GetComponent<CanvasGroup>();
                clone.collided = false;

            }

            count1 -= 1;
            value -= 1;
            Destroy(CatGO1[0].gameObject);
            CatGO1.RemoveAt(0);
        }
        else if (count01 >= 1 && value >= 0.1)
        {
            for (int i = 0; i < 10; i++)
            {
                CatImage clone = Instantiate(cat001, positionLists[posPoint].Position[i].position, transform.rotation);
                GameObject CatGO = GameObject.Find("CatImage");
                clone.transform.SetParent(CatGO.transform);
                clone.transform.localScale = new Vector3(1, 1, 1);
                clone.canvasGroup = CatGO.GetComponent<CanvasGroup>();
                clone.collided = false;

            }

            count01 -= 1;
            value -= 0.1;
            Destroy(CatGO01[0].gameObject);
            CatGO01.RemoveAt(0);
        }
        CheckpPosPoint();
        checkValueBox();


    }

    public void Sum()
    {
        if (count01 >= 10 && value >= 1)
        {
            Debug.Log("0.1to1");
            CatImage clone = Instantiate(cat1, positionLists[posPoint].Position[0].position, transform.rotation);
            GameObject CatGO = GameObject.Find("CatImage");
            clone.transform.SetParent(CatGO.transform);
            clone.transform.localScale = new Vector3(1, 1, 1);
            clone.canvasGroup = CatGO.GetComponent<CanvasGroup>();
            clone.collided = false;

            count01 -= 10;
            value -= 1;
            for (int i = 0; i < 10; i++)
            {
                Destroy(CatGO01[0].gameObject);
                CatGO01.RemoveAt(0);
            }
        }
        else if (count001 >= 10 && value >= 0.1)
        {
            CatImage clone = Instantiate(cat01, positionLists[posPoint].Position[0].position, transform.rotation);
            GameObject CatGO = GameObject.Find("CatImage");
            clone.transform.SetParent(CatGO.transform);
            clone.transform.localScale = new Vector3(1, 1, 1);
            clone.canvasGroup = CatGO.GetComponent<CanvasGroup>();
            clone.collided = false;

            count001 -= 10;
            value -= 0.1;
            for (int i = 0; i < 10; i++)
            {
                Destroy(CatGO001[0].gameObject);
                CatGO001.RemoveAt(0);
            }
        }
        checkValueBox();
    }

    public void checkValueBox()
    {
        if (count1 == 0 || count01 == 0 || count001 == 0)
        {
            SplitButton.interactable = false;
            SumButton.interactable = false;
        }
        else if (count1 >= 1 || count01 >= 1 || count001 >= 1)
        {
            SplitButton.interactable = true;
        }
        if (count1 < 10 || count01 < 10 || count001 < 10)
        {
            SumButton.interactable = false;
        }
    }
    public void CheckpPosPoint()
    {
        if (posPoint >= 3)
        {
            posPoint = 0;
        }
        else
        {
            posPoint += 1;
        }
    }



    [System.Serializable]
    public class PositionList
    {
        public Transform[] Position;
    }
}
