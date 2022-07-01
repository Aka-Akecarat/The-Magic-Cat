using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
	public float timeStart = 10;
	public TextMeshProUGUI textBox;
	public bool timeOut = false;
	// Use this for initialization
	void Start()
	{
		textBox.text = timeStart.ToString();
	}

	// Update is called once per frame
	void Update()
	{
		timeStart -= Time.deltaTime;
		textBox.text = Mathf.Round(timeStart).ToString();
		
		if(timeStart <= 0)
        {
			timeOut = true;
			var i = SceneManager.GetActiveScene().name;
			if (i == "Level_1-1")
			{
				GameObject.Find("QuizManager").GetComponent<QuizManager>().incorrect();
			}
			else if (i == "Level_1-2")
			{
				GameObject.Find("QuizManager").GetComponent<QuizManager1_2>().incorrect();
			}
			else if (i == "Level_1-3")
			{
				GameObject.Find("QuizManager").GetComponent<QuizManager1_3>().incorrect();
			}
			else if (i == "Level_2-1")
			{
				GameObject.Find("QuizManager").GetComponent<QuizManager2_1>().incorrect();
			}
			else if (i == "Level_2-2")
			{
				GameObject.Find("QuizManager").GetComponent<QuizManager2_2>().incorrect();
			}
			else if (i == "Level_2-3")
			{
				GameObject.Find("QuizManager").GetComponent<QuizManager2_3>().incorrect();
			}
			else if (i == "Level_3-1")
			{
				GameObject.Find("QuizManager").GetComponent<QuizManager3_1>().incorrect();
			}
			else if (i == "Level_3-2")
			{
				GameObject.Find("QuizManager").GetComponent<QuizManager3_2>().incorrect();
			}
			else if (i == "Level_3-3")
			{
				GameObject.Find("QuizManager").GetComponent<QuizManager3_3>().incorrect();
			}
			else if (i == "Level_4-1")
			{
				GameObject.Find("QuizManager").GetComponent<QuizManager4_1>().incorrect();
			}
			else if (i == "Level_4-2")
			{
				GameObject.Find("QuizManager").GetComponent<QuizManager4_2>().incorrect();
			}
			else if (i == "Level_Boss")
			{
				GameObject.Find("QuizManager").GetComponent<QuizManager_Boss>().incorrect();
			}
		}
	}
}

