using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScoreButton : MonoBehaviour
{
    public LevelLoader levelLoader;
    public void ShowScore(int i)
    {
        GlobalControl.Instance.saveID = i;
        levelLoader.LoadNextLevel("Score");
    }
}
