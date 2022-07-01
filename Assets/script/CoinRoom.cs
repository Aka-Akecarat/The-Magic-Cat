using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinRoom : MonoBehaviour
{
    public GameObject[] Enemy;
	public QuestGiver questGiver;

	void Start()
    {
		questGiver = GameObject.Find("QuestGiver").GetComponent<QuestGiver>();
		questGiver.OpenQuest();
		Enemy = GameObject.FindGameObjectsWithTag("Enemy");
		Check();
	}

    public void Check()
    {
		var i = SceneManager.GetActiveScene().name;
		if (i == "coin")
		{
			if(GlobalControl.Instance.datas[0].data_1_1.lvlPass == true)
            {
				foreach(GameObject x in Enemy)
                {
					x.SetActive(false);
				}
			}
		}
		else if (i == "coin2")
		{
			if (GlobalControl.Instance.datas[0].data_1_2.lvlPass == true)
			{
				foreach (GameObject x in Enemy)
				{
					x.SetActive(false);
				}
			}
		}
		else if (i == "coin3")
		{
			if (GlobalControl.Instance.datas[0].data_1_3.lvlPass == true)
			{
				foreach (GameObject x in Enemy)
				{
					x.SetActive(false);
				}
			}
		}
		else if (i == "coin4")
		{
			if (GlobalControl.Instance.datas[0].data_2_1.lvlPass == true)
			{
				foreach (GameObject x in Enemy)
				{
					x.SetActive(false);
				}
			}
		}
		else if (i == "coin5")
		{
			if (GlobalControl.Instance.datas[0].data_2_2.lvlPass == true)
			{
				foreach (GameObject x in Enemy)
				{
					x.SetActive(false);
				}
			}
		}
		else if (i == "coin6")
		{
			if (GlobalControl.Instance.datas[0].data_2_3.lvlPass == true)
			{
				foreach (GameObject x in Enemy)
				{
					x.SetActive(false);
				}
			}
		}
		else if (i == "coin7")
		{
			if (GlobalControl.Instance.datas[0].data_3_1.lvlPass == true)
			{
				foreach (GameObject x in Enemy)
				{
					x.SetActive(false);
				}
			}
		}
		else if (i == "coin8")
		{
			if (GlobalControl.Instance.datas[0].data_3_2.lvlPass == true)
			{
				foreach (GameObject x in Enemy)
				{
					x.SetActive(false);
				}
			}
		}
		else if (i == "coin9")
		{
			if (GlobalControl.Instance.datas[0].data_3_3.lvlPass == true)
			{
				foreach (GameObject x in Enemy)
				{
					x.SetActive(false);
				}
			}
		}
		else if (i == "coin10")
		{
			if (GlobalControl.Instance.datas[0].data_4_1.lvlPass == true)
			{
				foreach (GameObject x in Enemy)
				{
					x.SetActive(false);
				}
			}
		}
		else if (i == "coin11")
		{
			if (GlobalControl.Instance.datas[0].data_4_2.lvlPass == true)
			{
				foreach (GameObject x in Enemy)
				{
					x.SetActive(false);
				}
			}
		}
		else if (i == "coin12")
		{
			if (GlobalControl.Instance.datas[0].data_boss.lvlPass == true)
			{
				foreach (GameObject x in Enemy)
				{
					x.SetActive(false);
				}
			}
		}
	}
}
