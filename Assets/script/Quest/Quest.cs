using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public string title;
    public bool isActive;
    public string description;

    public void Complete()
    {
        isActive = false;
        Debug.Log(title + "  ผ่านแล้ว");
    }
}
