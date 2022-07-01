using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transistion;
    public float TransistionTime;
    public Unit player;
    void Awake()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Unit>();
        }
        if (SceneManager.GetActiveScene().name == "Inside+" || SceneManager.GetActiveScene().name == "Inside-"
            || SceneManager.GetActiveScene().name == "Insidex" || SceneManager.GetActiveScene().name == "Insidex %")
        {
            if(GlobalControl.Instance.position != null)
            {
                player.SetPosition(GlobalControl.Instance.position[0], GlobalControl.Instance.position[1], GlobalControl.Instance.position[2]);
            }
        }
        if (SceneManager.GetActiveScene().name == "Dialogue")
        {
            FindObjectOfType<AudioManager>().SetSoundVol("Theme", 0.1f);
        }
    }
    public void LoadNextLevel(string SceneName)
    {
        StartCoroutine(LoadLevel(SceneName));
    }

    IEnumerator LoadLevel(string SceneName)
    {
        transistion.SetTrigger("Start");

        yield return new WaitForSeconds(TransistionTime);

        if (SceneName != null)
        {
            if (SceneName == "")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (SceneName == "last")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            else
            {
                SceneManager.LoadScene(SceneName);
            }
        }
    }


}
