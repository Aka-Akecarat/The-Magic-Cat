using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopMan : MonoBehaviour
{
    private bool triggerEntered = false;
    public GameObject Shop;
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
        triggerEntered = true;
        Debug.Log("trigger entered");

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // We reset this variable since character is no longer in the trigger
        triggerEntered = false;
        Debug.Log("trigger Exit");
    }


}
