using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFloor : MonoBehaviour
{
    private bool triggerEntered = false;
    public GameObject E;
    public GameObject FloorCanvas;
    public LevelLoader levelLoader;

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true)
        {
            FloorCanvas.SetActive(true);
            Debug.Log("E");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        triggerEntered = true;
        E.SetActive(true);
        Debug.Log("trigger entered");

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        triggerEntered = false;
        E.SetActive(false);
        Debug.Log("trigger Exit");
    }

    public void LoadFloor(string i)
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == i)
        {
            FloorCanvas.SetActive(false);
        }
        else
        {
            GlobalControl.Instance.position[0] = 0;
            GlobalControl.Instance.position[1] = 0;
            FloorCanvas.SetActive(false);
            levelLoader.LoadNextLevel(i);
        }
    }
    
}
