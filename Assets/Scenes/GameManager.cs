using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject pauseUI;
    public GameObject pauseGO;
    public GameObject settingGO;
    public GameObject SaveButton;
    public GameObject LoadButton;
    public GameObject RUSure;
    public Canvas MapCanvas;

    public string lastSceneName;
    public string currentSceneName;

    public QuestGiver questGiver;

    public GameObject HpPanel;
    public Slider hpSlider;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI HealthText;

    IComparer myComparer;
    public GameObject[] door;
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
        GameManager.Instance.Player.GetComponent<Unit>().currentHP = GlobalControl.Instance.currentHP;
        GameManager.Instance.Player.GetComponent<Unit>().currentMoney = GlobalControl.Instance.currentMoney;
        Player = GameObject.FindWithTag("Player");
        GlobalControl.Instance.currentHP = Player.GetComponent<Unit>().currentHP;
        GlobalControl.Instance.currentMoney = Player.GetComponent<Unit>().currentMoney;
        questGiver = GameObject.Find("QuestGiver").GetComponent<QuestGiver>();
        setDoor();
    }
    void Update()
    {
        MapCanvas = GameObject.Find("MapCanvas").GetComponent<Canvas>();
        if (Input.GetKeyDown(KeyCode.Escape))
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
                Resume();
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(MapCanvas.isActiveAndEnabled);
            if (MapCanvas.isActiveAndEnabled == true )
            {
                MapCanvas.enabled = false;
            }
            else
            {
                MapCanvas.enabled = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "Inside+" || SceneManager.GetActiveScene().name == "Inside-"
            || SceneManager.GetActiveScene().name == "Insidex" || SceneManager.GetActiveScene().name == "Insidex %")
        {
            if (questGiver != null) { questGiver.OpenQuest(); }

            if (GameObject.Find("HPPanel") != null)
            {
                HpPanel = GameObject.Find("HPPanel");
                hpSlider = HpPanel.GetComponentInChildren<Slider>();
                HealthText = HpPanel.GetComponentInChildren<TextMeshProUGUI>();
                fill = GameObject.Find("Fill").GetComponent<Image>();
            }
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(Player.GetComponent<Unit>());
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer(null);
        GlobalControl.Instance.currentHP = data.currentHP;
        GlobalControl.Instance.currentMoney = data.currentMoney;
        //-------------------------------nightmare---------------------------------------//
        GlobalControl.Instance.datas[0].data_1_1.lvlPass = data.datas[0].data_1_1.lvlPass;
        GlobalControl.Instance.datas[0].data_1_1.correct = data.datas[0].data_1_1.correct;
        GlobalControl.Instance.datas[0].data_1_1.wrong = data.datas[0].data_1_1.wrong;
        GlobalControl.Instance.datas[0].data_1_2.lvlPass = data.datas[0].data_1_2.lvlPass;
        GlobalControl.Instance.datas[0].data_1_2.correct = data.datas[0].data_1_2.correct;
        GlobalControl.Instance.datas[0].data_1_2.wrong = data.datas[0].data_1_2.wrong;
        GlobalControl.Instance.datas[0].data_1_3.lvlPass = data.datas[0].data_1_3.lvlPass;
        GlobalControl.Instance.datas[0].data_1_3.correct = data.datas[0].data_1_3.correct;
        GlobalControl.Instance.datas[0].data_1_3.wrong = data.datas[0].data_1_3.wrong;

        GlobalControl.Instance.datas[0].data_2_1.lvlPass = data.datas[0].data_2_1.lvlPass;
        GlobalControl.Instance.datas[0].data_2_1.correct = data.datas[0].data_2_1.correct;
        GlobalControl.Instance.datas[0].data_2_1.wrong = data.datas[0].data_2_1.wrong;
        GlobalControl.Instance.datas[0].data_2_2.lvlPass = data.datas[0].data_2_2.lvlPass;
        GlobalControl.Instance.datas[0].data_2_2.correct = data.datas[0].data_2_2.correct;
        GlobalControl.Instance.datas[0].data_2_2.wrong = data.datas[0].data_2_2.wrong;
        GlobalControl.Instance.datas[0].data_2_3.lvlPass = data.datas[0].data_2_3.lvlPass;
        GlobalControl.Instance.datas[0].data_2_3.correct = data.datas[0].data_2_3.correct;
        GlobalControl.Instance.datas[0].data_2_3.wrong = data.datas[0].data_2_3.wrong;

        GlobalControl.Instance.datas[0].data_3_1.lvlPass = data.datas[0].data_3_1.lvlPass;
        GlobalControl.Instance.datas[0].data_3_1.correct = data.datas[0].data_3_1.correct;
        GlobalControl.Instance.datas[0].data_3_1.wrong = data.datas[0].data_3_1.wrong;
        GlobalControl.Instance.datas[0].data_3_2.lvlPass = data.datas[0].data_3_2.lvlPass;
        GlobalControl.Instance.datas[0].data_3_2.correct = data.datas[0].data_3_2.correct;
        GlobalControl.Instance.datas[0].data_3_2.wrong = data.datas[0].data_3_2.wrong;
        GlobalControl.Instance.datas[0].data_3_3.lvlPass = data.datas[0].data_3_3.lvlPass;
        GlobalControl.Instance.datas[0].data_3_3.correct = data.datas[0].data_3_3.correct;
        GlobalControl.Instance.datas[0].data_3_3.wrong = data.datas[0].data_3_3.wrong;

        GlobalControl.Instance.datas[0].data_4_1.lvlPass = data.datas[0].data_4_1.lvlPass;
        GlobalControl.Instance.datas[0].data_4_1.correct = data.datas[0].data_4_1.correct;
        GlobalControl.Instance.datas[0].data_4_1.wrong = data.datas[0].data_4_1.wrong;
        GlobalControl.Instance.datas[0].data_4_2.lvlPass = data.datas[0].data_4_2.lvlPass;
        GlobalControl.Instance.datas[0].data_4_2.correct = data.datas[0].data_4_2.correct;
        GlobalControl.Instance.datas[0].data_4_2.wrong = data.datas[0].data_4_2.wrong;
        GlobalControl.Instance.datas[0].data_boss.lvlPass = data.datas[0].data_boss.lvlPass;
        GlobalControl.Instance.datas[0].data_boss.correct = data.datas[0].data_boss.correct;
        GlobalControl.Instance.datas[0].data_boss.wrong = data.datas[0].data_boss.wrong;
        //-------------------------------nightmare---------------------------------------//
        Player.GetComponent<Unit>().currentHP = GlobalControl.Instance.currentHP;
        Player.GetComponent<Unit>().currentMoney = GlobalControl.Instance.currentMoney;
        SetHP();

    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        RUSure.SetActive(false);
    }
    public void Setting()
    {
        settingGO.SetActive(true);
        pauseGO.SetActive(false);
        Debug.Log("Setting");
    }
    public void CloseSetting()
    {
        settingGO.SetActive(false);
        pauseGO.SetActive(true);
        Debug.Log("Setting");
    }
    public void Exit()
    {
        RUSure.SetActive(true);
    }
    public void CancelExit()
    {
        RUSure.SetActive(false);
    }
    public void ExitGame()
    {
        SavePlayer();
        RUSure.SetActive(true);
        Debug.Log("Exit");
        Application.Quit();
    }
    public void ToMenu()
    {
        SavePlayer();
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");

    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        SceneChange();
        if (GameObject.FindWithTag("Player"))
        {
            Player = GameObject.FindWithTag("Player");
            Player.GetComponent<Unit>().currentHP = GlobalControl.Instance.currentHP;
            Player.GetComponent<Unit>().currentMoney = GlobalControl.Instance.currentMoney;
            if (GameObject.Find("SButton"))
            {
                SaveButton = GameObject.Find("SButton");
                SaveButton.GetComponent<Button>().onClick.AddListener(SavePlayer);
            }
            if (GameObject.Find("LButton"))
            {
                LoadButton = GameObject.Find("LButton");
                LoadButton.GetComponent<Button>().onClick.AddListener(LoadPlayer);
            }
            Debug.Log("Level Loaded");
            Debug.Log(scene.name);
            Debug.Log(mode);
            if (scene.name == "coin" || scene.name == "coin2" || scene.name == "coin3" || scene.name == "coin4"
                || scene.name == "coin5" || scene.name == "coin6" || scene.name == "coin7" || scene.name == "coin8"
                || scene.name == "coin9" || scene.name == "coin10" || scene.name == "coin11" || scene.name == "coin12")
            {
                SavePlayer();
                if(lastSceneName == "Level_1-1" || lastSceneName == "Level_1-2" || lastSceneName == "Level_1-3" ||
                    lastSceneName == "Level_2-1" || lastSceneName == "Level_2-2" || lastSceneName == "Level_2-3" ||
                    lastSceneName == "Level_3-1" || lastSceneName == "Level_3-2" || lastSceneName == "Level_3-3" ||
                    lastSceneName == "Level_4-1" || lastSceneName == "Level_4-2" || lastSceneName == "Level_Boss")
                {
                    GlobalControl.Instance.position[0] -= 2;
                    SetPlayer();
                }
            }
            else if (scene.name == "Inside+" || scene.name == "Inside-"
                || scene.name == "Insidex" || scene.name == "Insidex %")
            {
                SavePlayer();
                Debug.Log("SetPlayer");
                if (lastSceneName == "Inside+" || lastSceneName == "Inside-" 
                    || lastSceneName == "Insidex" || lastSceneName == "Insidex %")
                {
                    GlobalControl.Instance.outsidePosition[0] = 0;
                    GlobalControl.Instance.outsidePosition[1] = 0;
                }
                SetPlayerOutside();
                setDoor();
            }
        }
        else
        {
            return;
        }
    }

    public void SetHP()
    {
        hpSlider.value = GlobalControl.Instance.currentHP;
        fill.color = gradient.Evaluate(hpSlider.normalizedValue);
        HealthText.text = GlobalControl.Instance.currentHP.ToString();
        HealthText.color = gradient.Evaluate(hpSlider.normalizedValue);
    }

    public void setDoor()
    {
        door = GameObject.FindGameObjectsWithTag("Door");
        if (door != null)
        {
            IComparer myComparer = new DoorSorter();
            Array.Sort(door, myComparer);
            foreach (UnityEngine.Object obj in door)
            {
                Debug.Log("obj = " + obj.name);
            }
            if (Array.Exists(door, x => x.name == "door_1.2"))
            {
                if (GlobalControl.Instance.datas[0].data_1_2.lvlPass != true)
                {
                    
                }
            }
            foreach(GameObject i in door)
            {
                if (GlobalControl.Instance.datas[0].data_1_1.lvlPass != true)
                {
                    if(i.name == "door_1.2")
                    {
                        i.SetActive(false);
                    }
                }
                if (GlobalControl.Instance.datas[0].data_1_2.lvlPass != true)
                {
                    if (i.name == "door_1.3")
                    {
                        i.SetActive(false);
                    }
                }
                if (GlobalControl.Instance.datas[0].data_1_3.lvlPass != true)
                {
                    if (i.name == "door_2.1")
                    {
                        i.SetActive(false);
                    }
                }
                if (GlobalControl.Instance.datas[0].data_2_1.lvlPass != true)
                {
                    if (i.name == "door_2.2")
                    {
                        i.SetActive(false);
                    }
                }
                if (GlobalControl.Instance.datas[0].data_2_2.lvlPass != true)
                {
                    if (i.name == "door_2.3")
                    {
                        i.SetActive(false);
                    }
                }
                if (GlobalControl.Instance.datas[0].data_2_3.lvlPass != true)
                {
                    if (i.name == "door_3.1")
                    {
                        i.SetActive(false);
                    }
                }
                if (GlobalControl.Instance.datas[0].data_3_1.lvlPass != true)
                {
                    if (i.name == "door_3.2")
                    {
                        i.SetActive(false);
                    }
                }
                if (GlobalControl.Instance.datas[0].data_3_2.lvlPass != true)
                {
                    if (i.name == "door_3.3")
                    {
                        i.SetActive(false);
                    }
                }
                if (GlobalControl.Instance.datas[0].data_3_3.lvlPass != true)
                {
                    if (i.name == "door_4.1")
                    {
                        i.SetActive(false);
                    }
                }

                if (GlobalControl.Instance.datas[0].data_4_1.lvlPass != true)
                {
                    if (i.name == "door_4.2")
                    {
                        i.SetActive(false);
                    }
                }
                if (GlobalControl.Instance.datas[0].data_4_2.lvlPass != true)
                {
                    if (i.name == "door_Boss")
                    {
                        i.SetActive(false);
                    }
                }
            }
        }
    }

    public void SetPlayer()
    {
        if (GlobalControl.Instance.position[0] != 0 || GlobalControl.Instance.position[1] != 0)
        {
        Player.transform.position = new Vector3(GlobalControl.Instance.position[0], GlobalControl.Instance.position[1], GlobalControl.Instance.position[2]);
        }
    }
    public void SetPlayerOutside()
    {
        if (GlobalControl.Instance.outsidePosition[0] != 0 || GlobalControl.Instance.outsidePosition[1] != 0)
        {
            Player.transform.position = new Vector3(GlobalControl.Instance.outsidePosition[0], GlobalControl.Instance.outsidePosition[1], GlobalControl.Instance.outsidePosition[2]);
        }
    }

    public void SceneChange()
    {
        if(currentSceneName != SceneManager.GetActiveScene().name)
        {
            lastSceneName = currentSceneName;
            currentSceneName = SceneManager.GetActiveScene().name;
        }
    }
}
