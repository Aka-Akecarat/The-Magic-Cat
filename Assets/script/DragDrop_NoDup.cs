using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop_NoDup : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    public double value = 0.00d;
    private RectTransform rectTransform;
    public DragDrop_NoDup Pic;
    private CanvasGroup canvasGroup;
    public Transform Position;
    public CatImage catImage;
    public GameObject[] CatPic;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();  
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        Pic = this;
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .7f;
        canvasGroup.blocksRaycasts = false;
        catImage.canvasGroup.blocksRaycasts = false;
          
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
        catImage.canvasGroup.blocksRaycasts = true;

        DragDrop_NoDup clone = Instantiate(Pic, Position.position, transform.rotation);
        GameObject canvas = GameObject.Find("Canvas");
        clone.transform.SetParent(canvas.transform);
        clone.transform.localScale = new Vector3(1, 1, 1);

        Destroy(this.gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }
}
