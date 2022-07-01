using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public SaveSlot[] saveButton;
    public GameObject setNameCanvas;
    public InputField nameField;
    string nameSave;

    private void Start()
    {
        for(int i = 1; i <= 3; i++)
        {
            LoadWhenStartGame();
        }
    }
    public void PlayGame(int i){
        
        var path = Application.persistentDataPath + "/" + i + "/player.ree";
        if (File.Exists(path))
        {
            PlayerData data = SaveSystem.LoadPlayer(i);
            SceneManager.LoadScene(data.BeforeSaveSceneName);

            GlobalControl.Instance.saveName = data.saveName;
            GlobalControl.Instance.saveID = data.saveID;
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
        }
        else
        {
            setNameCanvas.SetActive(true);
            Directory.CreateDirectory(Application.persistentDataPath + "/" + i);
            GlobalControl.Instance.saveID = saveButton[i-1].saveID;
            thing(i);
        }
        
    }

    public void QuitGame(){
        Debug.Log("Quit of Exit Button");
        Application.Quit();
    } 
    
    public void thing(int i)
    {
        var se = new InputField.SubmitEvent();
        se.AddListener(GetAnswer);
        nameField.onEndEdit = se;
        nameField.Select();
    }

    public void GetAnswer(string arg0)
    {
        Debug.Log(arg0);
        nameSave = (arg0);
    }

    public void startGame()
    {
        GlobalControl.Instance.saveName = nameSave;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadWhenStartGame()
    {
        for (int i = 1; i <= 3; i++)
        {
            var path = Application.persistentDataPath + "/" + i + "/player.ree";
            if (File.Exists(path))
            {
                PlayerData data = SaveSystem.LoadPlayer(i);
                saveButton[i - 1].nameText.text = data.saveName.ToString();
                saveButton[i - 1].ScoreButton.gameObject.SetActive(true);
                saveButton[i - 1].ThisButton.SetActive(true);
                Debug.Log("have");
            }
            else
            {
                saveButton[i - 1].nameText.text = "เริ่มเกมใหม่";
                saveButton[i - 1].ScoreButton.gameObject.SetActive(false);
                saveButton[i - 1].ThisButton.SetActive(false);
                Debug.Log("Not have");
            }
        }
    }
}
