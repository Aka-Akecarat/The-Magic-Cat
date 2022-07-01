using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatImage_Minus : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    public double value;
    private RectTransform rectTransform;
    public CatImage_Minus Pic;
    public CanvasGroup canvasGroup;
    public CanvasGroup otherCanvasGroup;
    public GameObject squareCount;
    public Vector3 PositionPoint;
    public Vector3 OutsidePosition;
    public bool collided;
    public bool fromOutside;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        PositionPoint = this.transform.position;
        Pic = this;
        collided = false;
        //OutsidePosition = new Vector3(PositionPoint.x, 49, PositionPoint.z);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .7f;
        canvasGroup.blocksRaycasts = false;
        otherCanvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta /canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        otherCanvasGroup.blocksRaycasts = true;

        if (collided == false)
        {
            Debug.Log("This is Outside");
            if (squareCount.GetComponent<SquareCount>().SumValue > 0)
            {
                if (this.fromOutside != true)
                {
                    squareCount.GetComponent<SquareCount>().SumValue -= value;
                    GoBackWhenOutside();
                }
                else
                {
                    GoBack();
                    return;
                }
                    if(squareCount.GetComponent<SquareCount>().SumValue < 10 )
                    {
                            squareCount.GetComponent<SquareCount>().count -= 1;
                    }
                    //check if SumValue = 0
                    if (squareCount.GetComponent<SquareCount>().SumValue < 0 &&
                        squareCount.GetComponent<SquareCount>().SumValue < value)
                    {
                        squareCount.GetComponent<SquareCount>().SumValue = 0;
                    if (squareCount.GetComponent<SquareCount>().count < 10)
                    {
                        this.gameObject.SetActive(false);
                    }
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
                        if (squareCount.GetComponent<SquareCount>().count < 10 ) 
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
            //GoBackWhenOutside();
        }
        else
        {
            Debug.Log(eventData.pointerDrag.name);
            collided = false;
        }
        squareCount.GetComponent<SquareCount>().CheckSwapButton();
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
        //this.gameObject.SetActive(false);
    }
    public void GoBackWhenOutside()
    {
        GoBack();
        squareCount.GetComponent<SquareCount>().OutsideCatPic[squareCount.GetComponent<SquareCount>().outsideCount].SetActive(true);
        squareCount.GetComponent<SquareCount>().outsideCount += 1;
    }

    public void SetBack()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        otherCanvasGroup.blocksRaycasts = true;
    }

    public void minus()
    {
        squareCount.GetComponent<SquareCount>().SumValue -= value;
        squareCount.GetComponent<SquareCount>().count -=1;
        squareCount.GetComponent<SquareCount>().setText();
    }
}
