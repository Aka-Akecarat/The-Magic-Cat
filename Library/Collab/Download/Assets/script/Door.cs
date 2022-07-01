using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    private bool triggerEntered = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true)
        {
           levelLoader.LoadNextLevel();
           Debug.Log("E");
        }
    }
    public LevelLoader levelLoader;
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
