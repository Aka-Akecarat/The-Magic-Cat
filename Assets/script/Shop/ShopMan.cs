using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopMan : MonoBehaviour
{
    private bool triggerEntered = false;
    public GameObject Shop;
    public GameObject E;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true)
        {
            Shop.SetActive(true);
            Debug.Log("E");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        E.SetActive(true);
        triggerEntered = true;
        Debug.Log("trigger entered");

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (E.activeSelf)
        {
            Shop.SetActive(false);
        }
        E.SetActive(false);
        triggerEntered = false;
        Debug.Log("trigger Exit");
    }


}
