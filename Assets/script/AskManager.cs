using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AskManager : MonoBehaviour
{
    public LevelLoader levelLoader;

    public void Back()
    {
        levelLoader.LoadNextLevel(GlobalControl.Instance.LastSceneName);
    }
    public void Go()
    {
        GlobalControl.Instance.BoxPass = false;
        levelLoader.LoadNextLevel(GlobalControl.Instance.NextSceneName);
    }
}
