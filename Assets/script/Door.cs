using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool triggerEntered = false;
    public string SceneName;
    public GameObject E;
    public LevelLoader levelLoader;
    private void Start()
    {
        if (GameObject.Find("E")!=null)
        {
            E = GameObject.Find("E");
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true)
        {
            if (SceneManager.GetActiveScene().name == "Inside+" || SceneManager.GetActiveScene().name == "Inside-"
                || SceneManager.GetActiveScene().name == "Insidex" || SceneManager.GetActiveScene().name == "Insidex %" )
            {
                if(GlobalControl.Instance.position == null)
                {
                    GlobalControl.Instance.position = new float[3];
                }
                if (GlobalControl.Instance.outsidePosition == null)
                {
                    GlobalControl.Instance.outsidePosition = new float[3];
                }
                GlobalControl.Instance.outsidePosition[0] = transform.position.x;
                GlobalControl.Instance.outsidePosition[1] = transform.position.y;
                GlobalControl.Instance.outsidePosition[2] = transform.position.z;
            }
            levelLoader.LoadNextLevel(SceneName);
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
         // We reset this variable since character is no longer in the trigger
         triggerEntered = false;
         E.SetActive(false);
         Debug.Log("trigger Exit");
    }


}
