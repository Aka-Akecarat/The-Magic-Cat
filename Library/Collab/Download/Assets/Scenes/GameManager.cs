using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject pauseUI;

    public static GameManager Instance;
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
    }
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        GlobalControl.Instance.currentHP = Player.GetComponent<Unit>().currentHP;
        GlobalControl.Instance.currentMoney = Player.GetComponent<Unit>().currentMoney;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                //หยุดเกม
                Time.timeScale = 0;
                pauseUI.SetActive(true);
            }
            else
            {
                //เล่นเกมต่อ
                Time.timeScale = 1;
                pauseUI.SetActive(false);
            }
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(Player.GetComponent<Unit>());
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Debug.Log("currentHP :" + data.currentHP);
        Debug.Log("currentMoney :" + data.currentMoney);
    }
    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (GameObject.FindWithTag("Player"))
        {
            Player = GameObject.FindWithTag("Player");
            Player.GetComponent<Unit>().currentHP = GlobalControl.Instance.currentHP;
            Player.GetComponent<Unit>().currentMoney = GlobalControl.Instance.currentMoney;
            Debug.Log("Level Loaded");
            Debug.Log(scene.name);
            Debug.Log(mode);
        }
    }
}
