using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CatGroup : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private CanvasGroup insidecanvasGroup;
    public CatGroup Pic;
    public GameObject insideCatGroup;
    public Transform Position;
    public Busket busket;
    public bool collided = false;
    public bool outside = true;
    public double value;
    public GameObject[] CatPic1;
    public GameObject[] CatPic01;
    public GameObject[] CatPic001;
    public Text MultiplyText;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        insideCatGroup = GameObject.Find("InsideCatGroup");
        insidecanvasGroup = insideCatGroup.GetComponent<CanvasGroup>();
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        Pic = this;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .7f;
        canvasGroup.blocksRaycasts = false;
        insidecanvasGroup.alpha = .7f;
        insidecanvasGroup.blocksRaycasts = false;
        /*
        var x = GameObject.FindGameObjectsWithTag("Clone");
        foreach (var i in x)
        {
            if(i.GetComponent<CatGroup>())
            {
                i.GetComponent<CatGroup>().canvasGroup.blocksRaycasts = false;
            }
            if (i.GetComponent<InsideCatGroup>())
            {
                i.GetComponent<InsideCatGroup>().canvasGroup.blocksRaycasts = false;
            }
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
        insidecanvasGroup.alpha = 1f;
        insidecanvasGroup.blocksRaycasts = true;

        var x = GameObject.FindGameObjectsWithTag("Clone");
        /*
        foreach (var i in x)
        {
            i.GetComponent<CatGroup>().canvasGroup.blocksRaycasts = true;
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
                /*
                CatGroup clone = Instantiate(Pic, Position.position, transform.rotation);
                GameObject canvas = GameObject.Find("Canvas(2)");
                clone.transform.SetParent(canvas.transform);
                clone.transform.localScale = new Vector3(1, 1, 1);
                clone.collided = false;
                clone.outside = true;
                */
                collided = false;
                outside = true;
                insideCatGroup.GetComponent<InsideCatGroup>().activeThis.SetActive(true);
                insideCatGroup.GetComponent<InsideCatGroup>().MultiplyValue += busket.MultipleDragValue;
                insideCatGroup.GetComponent<InsideCatGroup>().setMText();
                busket.value += value * busket.MultipleDragValue;
                busket.value = System.Math.Round(busket.value, 2);
                this.transform.position = Position.position;
            }
        }
        else if (collided == false && outside == true)
        {
            /*
            CatGroup clone = Instantiate(Pic, Position.position, transform.rotation);
            GameObject canvas = GameObject.Find("Canvas(2)");
            clone.transform.SetParent(canvas.transform);
            clone.transform.localScale = new Vector3(1, 1, 1);
            clone.collided = false;
            clone.outside = true;
            this.gameObject.SetActive(false);
            */
            this.transform.position = Position.position;
            Debug.Log("collided == false && outside == true");
        }
        else
        {
            Debug.Log("else");
            insideCatGroup.GetComponent<InsideCatGroup>().MultiplyValue -= busket.MultipleDragValue;
            insideCatGroup.GetComponent<InsideCatGroup>().setMText();
            busket.value -= value * busket.MultipleDragValue;
            busket.value = System.Math.Round(busket.value, 2);
            if(insideCatGroup.GetComponent<InsideCatGroup>().MultiplyValue <= 0)
            {
                insideCatGroup.GetComponent<InsideCatGroup>().activeThis.SetActive(true);
            }
            this.gameObject.SetActive(false);
        }
        busket.setText();
    }
}
