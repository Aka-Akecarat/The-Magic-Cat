using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InsideCatGroup : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private CanvasGroup insidecanvasGroup;
    public GameObject activeThis;
    public InsideCatGroup Pic;
    public Transform Position;
    public Busket busket;
    public bool collided = false;
    public bool outside = true;
    public double value;
    public GameObject[] CatPic1;
    public GameObject[] CatPic01;
    public GameObject[] CatPic001;
    public int MultiplyValue;
    public Text MultiplyText;
    public CatGroup catGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        Pic = this;
        value = catGroup.value;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .7f;
        canvasGroup.blocksRaycasts = false;
        var x = GameObject.FindGameObjectsWithTag("Clone");
        /*
        foreach (var i in x)
        {
            i.GetComponent<InsideCatGroup>().canvasGroup.blocksRaycasts = false;
        }
        */
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        /*
        var x = GameObject.FindGameObjectsWithTag("Clone");
        foreach (var i in x)
        {
            i.GetComponent<InsideCatGroup>().canvasGroup.blocksRaycasts = true;
        }
        */
        if (collided == true)
        {
            if (outside == false) 
            {
                collided = false;
                return;
            }
            else
            {
                InsideCatGroup clone = Instantiate(Pic, Position.position, transform.rotation);
                GameObject canvas = GameObject.Find("Canvas(2)");
                clone.transform.SetParent(canvas.transform);
                clone.transform.localScale = new Vector3(1, 1, 1);
                clone.collided = false;
                clone.outside = true;
                collided = false;
                outside = false;
                busket.value += value * busket.MultipleDragValue;
                busket.value = System.Math.Round(busket.value, 2);
            }
        }
        else if (collided == false && outside == true)
        {
            InsideCatGroup clone = Instantiate(Pic, Position.position, transform.rotation);
            GameObject canvas = GameObject.Find("Canvas(2)");
            clone.transform.SetParent(canvas.transform);
            clone.transform.localScale = new Vector3(1, 1, 1);
            clone.collided = false;
            clone.outside = true;
            this.gameObject.SetActive(false);
            Debug.Log("collided == false && outside == true");
        }
        else
        {
            Debug.Log("else");
            busket.value -= value * busket.MultipleDragValue;
            busket.value = System.Math.Round(busket.value, 2);
            busket.setText();
            MultiplyValue -= busket.MultipleDragValue;
            if(MultiplyValue <= 0)
            {
                busket.value = 0;
                MultiplyValue = 0;
                activeThis.gameObject.SetActive(false);
                
            }
            setMText();
            goBack();

        }
        busket.setText();
    }

    public void setMText()
    {
        MultiplyText.text = "X"+MultiplyValue.ToString();
    }

    public void goBack()
    {
        transform.position = Position.position;
    }
}
