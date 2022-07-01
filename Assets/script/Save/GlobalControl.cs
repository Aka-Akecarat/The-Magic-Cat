using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public int saveID;
    public string saveName;

    public int currentHP;
    public int currentMoney;
    public float[] outsidePosition;
    public float[] position;
    public string NextSceneName;
    public string LastSceneName;
    public bool BoxPass;

    public string BeforeSaveSceneName;
    public List<data> datas = new List<data>();
    public Quest quest;
    public static GlobalControl Instance;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        datas.Capacity = 1;
    }
}