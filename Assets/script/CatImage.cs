using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatImage : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    public double value;
    private RectTransform rectTransform;
    public CatImage Pic;
    public CanvasGroup canvasGroup;
    public GameObject squareCount;
    public GameObject DiVsquareCount;
    public GameObject Position;
    public Vector3 PositionPoint;
    public bool collided;
    public bool insideChangeValueBox;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        PositionPoint = this.transform.position;
        Pic = this;
        collided = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .7f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;


        if (collided == false)
        {
            if (squareCount == null)
            {
                Debug.Log("No squareCount");
                return;
            }
            if (squareCount.GetComponent<SquareCount>() != null)
            {
                Debug.Log("This is Outside");
                if (squareCount.GetComponent<SquareCount>().SumValue > 0)
                {
                    squareCount.GetComponent<SquareCount>().SumValue -= value;
                    
                        squareCount.GetComponent<SquareCount>().count -= 1;
                    
                    //check if SumValue = 0
                    if (squareCount.GetComponent<SquareCount>().SumValue < 0 &&
                        squareCount.GetComponent<SquareCount>().SumValue < value)
                    {
                        squareCount.GetComponent<SquareCount>().SumValue = 0;
                    
                        this.gameObject.SetActive(false);
                        GoBack();
                    }
                    else
                    {
                        if(squareCount.GetComponent<SquareCount>().SumValue >0 &&
                            squareCount.GetComponent<SquareCount>().SumValue < 1)
                        {
                            squareCount.GetComponent<SquareCount>().SumValue
                                = System.Math.Round(squareCount.GetComponent<SquareCount>().SumValue, 2);
                        }
                        if (squareCount.GetComponent<SquareCount>().SumValue < squareCount.GetComponent<SquareCount>().acceptValue * 10 ) 
                        {
                            this.gameObject.SetActive(false);
                        }
                        GoBack();
                    }
                    squareCount.GetComponent<SquareCount>().setText();
                }
                else
                {
               
                    this.gameObject.SetActive(false);
                }
            }
            else if (squareCount.GetComponent<Busket>() != null)
            {
                Busket B = squareCount.GetComponent<Busket>();
                if (value == 1)
                {
                    B.CatPic1Count -= B.MultipleDragValue;
                    if (B.CatPic1.Length > B.CatPic1Count)
                    {
                        for (int i = B.CatPic1.Length - 1; i >= B.CatPic1Count; i--)
                        {

                            B.CatPic1[i].SetActive(false);
                            Debug.Log(i);
                        }
                    }
                }
                else if (value == 0.1)
                {
                    B.CatPic01Count -= B.MultipleDragValue;
                    if (B.CatPic01.Length > B.CatPic01Count)
                    {
                        for (int i = B.CatPic01.Length - 1; i >= B.CatPic01Count; i--)
                        {

                            B.CatPic01[i].SetActive(false);
                            Debug.Log(i);
                        }
                    }
                }
                else if (value == 0.01)
                {
                    B.CatPic001Count -= B.MultipleDragValue;
                    if (B.CatPic001.Length > B.CatPic001Count)
                    {
                        for (int i = B.CatPic001.Length - 1; i >= B.CatPic001Count; i--)
                        {

                            B.CatPic001[i].SetActive(false);
                            Debug.Log(i);
                        }
                    }
                }
                B.value -= value * B.MultipleDragValue;
                B.value = System.Math.Round(B.value, 2); ;
                GoBack();
                B.setText();
            }
            else if (squareCount.GetComponent<DivideBasket>() != null)
            {
                squareCount.GetComponent<DivideBasket>().value -= value;
                squareCount.GetComponent<DivideBasket>().SetValueText();
                Debug.Log("1");
                squareCount = null;
            }
            else if (squareCount.GetComponent<ChangeValueBox>() != null)
            {
                var box = squareCount.GetComponent<ChangeValueBox>();
                box.value -= value;
                insideChangeValueBox = false;
                if (value == 1)
                {
                    box.count1 -= 1;
                }
                else if(value == 0.1)
                {
                    box.count01 -= 1;
                }
                else if (value == 0.01)
                {
                    box.count001 -= 1;
                }
                if (box.count01 < 10 || box.count001 < 10)
                {
                    box.SumButton.interactable = false;
                }
            }
        }
        else
        {
            Debug.Log(eventData.pointerDrag.name);
            collided = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        
    }

    public void GoBack()
    {
        Pic.transform.position = PositionPoint;
    }
}
