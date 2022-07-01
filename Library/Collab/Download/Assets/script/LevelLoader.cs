using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int NextSceneIndex;
    public Animator transistion;
    public float TransistionTime;
    // Update is called once per frame
    void Update()
    {
    
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(NextSceneIndex));
    }

    IEnumerator LoadLevel(int Next)
    {
        transistion.SetTrigger("Start");

        yield return new WaitForSeconds(TransistionTime);

        SceneManager.LoadScene(Next);
    }
}
