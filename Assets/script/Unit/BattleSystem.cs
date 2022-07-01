using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public GameObject quizManagerGO;
	public GameObject quizCanvas;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	Unit playerUnit;
	Unit enemyUnit;

	public TextMeshProUGUI MoneyText;

	public GameObject hintCanvas;
	public GameObject[] hintImage;
	public int hintIndex = 0;

	public GameObject guideCanvas;
	public GameObject[] guideImage;
	public int guideIndex = 0;

	public Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;
	public string SceneName;
	

	string help;

	void Start()
	{
		state = BattleState.START;
		StartCoroutine(SetupBattle());
	}

	IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();
		playerUnit.currentHP = GlobalControl.Instance.currentHP;
		playerUnit.currentMoney = GlobalControl.Instance.currentMoney;
		playerUnit.GetComponent<PlayerMovement>().enabled = false;
		var x = GlobalControl.Instance.currentMoney.ToString();
		MoneyText.text = x;

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();

		dialogueText.text = enemyUnit.unitName + " ปรากฎตัว...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}
	public void Attack() 
	{
		playerUnit.Attack();
	}
	
	public void PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
		

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "โจมตีสำเร็จ!";

		if (isDead)
		{
			state = BattleState.WON;
			EndBattle();
			Debug.Log("EndBattle");
		}
		else
		{
			state = BattleState.PLAYERTURN;
			Debug.Log("EnemyTurn");
			PlayerTurn();
		}
	}
	public IEnumerator WrongAns()
    {
		var i = SceneManager.GetActiveScene().name;
		if (i == "Level_1-1")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager>();
			if (quizManager.CDTime.timeOut == true)
			{
				dialogueText.text = "เวลาของคุณหมด";
				yield return new WaitForSeconds(2f);
				quizManager.CDTime.timeOut = false;
			}

		}
		else if (i == "Level_1-2")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager1_2>();
			if (quizManager.CDTime.timeOut == true)
			{
				dialogueText.text = "เวลาของคุณหมด";
				yield return new WaitForSeconds(2f);
				quizManager.CDTime.timeOut = false;
			}
		}
		else if (i == "Level_1-3")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager1_3>();
			if (quizManager.CDTime.timeOut == true)
			{
				dialogueText.text = "เวลาของคุณหมด";
				yield return new WaitForSeconds(2f);
				quizManager.CDTime.timeOut = false;
			}
		}
		else if (i == "Level_2-1")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager2_1>();
			if (quizManager.CDTime.timeOut == true)
			{
				dialogueText.text = "เวลาของคุณหมด";
				yield return new WaitForSeconds(2f);
				quizManager.CDTime.timeOut = false;
			}
		}
		else if (i == "Level_2-2")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager2_2>();
			if (quizManager.CDTime.timeOut == true)
			{
				dialogueText.text = "เวลาของคุณหมด";
				yield return new WaitForSeconds(2f);
				quizManager.CDTime.timeOut = false;
			}
		}
		else if (i == "Level_2-3")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager2_3>();
			if (quizManager.CDTime.timeOut == true)
			{
				dialogueText.text = "เวลาของคุณหมด";
				yield return new WaitForSeconds(2f);
				quizManager.CDTime.timeOut = false;
			}
		}
		else if (i == "Level_3-1")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager3_1>();
			if (quizManager.CDTime.timeOut == true)
			{
				dialogueText.text = "เวลาของคุณหมด";
				yield return new WaitForSeconds(2f);
				quizManager.CDTime.timeOut = false;
			}
		}
		else if (i == "Level_3-2")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager3_2>();
			if (quizManager.CDTime.timeOut == true)
			{
				dialogueText.text = "เวลาของคุณหมด";
				yield return new WaitForSeconds(2f);
				quizManager.CDTime.timeOut = false;
			}
		}
		else if (i == "Level_3-3")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager3_3>();
			if (quizManager.CDTime.timeOut == true)
			{
				dialogueText.text = "เวลาของคุณหมด";
				yield return new WaitForSeconds(2f);
				quizManager.CDTime.timeOut = false;
			}
		}
		else if (i == "Level_4-1")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager4_1>();
			if (quizManager.CDTime.timeOut == true)
			{
				dialogueText.text = "เวลาของคุณหมด";
				yield return new WaitForSeconds(2f);
				quizManager.CDTime.timeOut = false;
			}
		}
		else if (i == "Level_4-2")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager4_2>();
			if (quizManager.CDTime.timeOut == true)
			{
				dialogueText.text = "เวลาของคุณหมด";
				yield return new WaitForSeconds(2f);
				quizManager.CDTime.timeOut = false;
			}
		}
		else if (i == "Level_Boss")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager_Boss>();
			if (quizManager.CDTime.timeOut == true)
			{
				dialogueText.text = "เวลาของคุณหมด";
				yield return new WaitForSeconds(2f);
				quizManager.CDTime.timeOut = false;
			}
		}
        else
        {
			dialogueText.text = "คุณตอบผิด";
			yield return new WaitForSeconds(2f);
        }
		
	}

	public IEnumerator RightAns()
	{
		dialogueText.text = "คุณตอบถูก";
		yield return new WaitForSeconds(1f);
		dialogueText.text = playerUnit.unitName + " โจมตี!";
	}
	public IEnumerator EnemyTurn()
	{
		yield return WrongAns();
		enemyUnit.Attack();

		dialogueText.text = enemyUnit.unitName + " โจมตี!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

		if (isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		}
		else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if (state == BattleState.WON)
		{
			enemyUnit.animator.Play("Die");
			dialogueText.text = "คุณชนะ!";
			SavePlayer();
			StartCoroutine(Win());
		}
		else if (state == BattleState.LOST)
		{
			playerUnit.animator.Play("Die");
			dialogueText.text = "คุณแพ้";
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "ตาของคุณแล้ว จะทำอย่างไร:";
	}
	IEnumerator Win()
    {
		yield return new WaitForSeconds(3f);
		QuitBattle();
	}
	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(5);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}
	
	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;
		StartQuiz();
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;
		
		StartCoroutine(PlayerHeal());
	}

	public void OnHintButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;
		hintCanvas.SetActive(true);
		guideIndex = 0;

	}

	public void OnCloseHintButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;
		hintCanvas.SetActive(false);

	}

	public void setNextHintActive()
	{
		if (hintIndex <= hintImage.Length - 2)
		{
			hintImage[hintIndex + 1].SetActive(true);
			hintImage[hintIndex].SetActive(false);
			hintIndex += 1;
		}
		else if (hintIndex == hintImage.Length - 1)
		{
			hintImage[hintIndex - (hintImage.Length - 1)].SetActive(true);
			hintImage[hintImage.Length - 1].SetActive(false);
			hintIndex -= hintImage.Length - 1;
		}
	}

	public void setPreviousHintActive()
	{
		if (hintIndex >= 1)
		{
			hintImage[hintIndex - 1].SetActive(true);
			hintImage[hintIndex].SetActive(false);
			hintIndex -= 1;
		}
		else if (hintIndex == 0)
		{
			hintImage[hintImage.Length - 1].SetActive(true);
			hintImage[hintIndex].SetActive(false);
			hintIndex = hintImage.Length - 1;
		}

	}

	public void OnGuideButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;
		guideCanvas.SetActive(true);
		guideIndex = 0;
		Debug.Log(guideImage.Length-1);

	}

	public void OnCloseGuideButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;
		guideCanvas.SetActive(false);

	}

	public void setNextGuideActive()
    {
		if(guideIndex <= guideImage.Length-2)
        {
			guideImage[guideIndex + 1].SetActive(true);
			guideImage[guideIndex].SetActive(false);
			guideIndex += 1;
        }
		else if (guideIndex == guideImage.Length-1)
        {
			guideImage[guideIndex - (guideImage.Length - 1)].SetActive(true);
			guideImage[guideImage.Length-1].SetActive(false);
			guideIndex -= guideImage.Length-1;
		}
	}

	public void setPreviousGuideActive()
	{
        if (guideIndex >= 1)
        {
			guideImage[guideIndex - 1].SetActive(true);
			guideImage[guideIndex].SetActive(false);
			guideIndex -= 1;
        }
		else if (guideIndex == 0)
        {
			guideImage[guideImage.Length-1].SetActive(true);
			guideImage[guideIndex].SetActive(false);
			guideIndex = guideImage.Length-1;
		}
		
	}
	public void SavePlayer()
	{

		savePlayData();
		GlobalControl.Instance.currentHP = playerUnit.currentHP;
		GlobalControl.Instance.currentMoney += enemyUnit.currentMoney;
		var x = GlobalControl.Instance.currentMoney.ToString();
		MoneyText.text = x;
	}
	public void StartQuiz()
    {
		quizCanvas.SetActive(true);
	}
	public void QuitBattle()
    {
		var x = GameObject.Find("LevelLoader");
		x.GetComponent<LevelLoader>().LoadNextLevel(SceneName);
		//GameManager.Instance.SavePlayer();
	}

	public void savePlayData()
    {
		
		var i = SceneManager.GetActiveScene().name;
		if (i == "Level_1-1")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager>();
			GlobalControl.Instance.datas[0].data_1_1.lvlPass = true;
			GlobalControl.Instance.datas[0].data_1_1.correct = quizManager.correctCount;
			GlobalControl.Instance.datas[0].data_1_1.wrong = quizManager.incorrectCount;
		}
		else if (i == "Level_1-2")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager1_2>();
			Debug.Log(quizManager);
			GlobalControl.Instance.datas[0].data_1_2.lvlPass = true;
			GlobalControl.Instance.datas[0].data_1_2.correct = quizManager.correctCount;
			GlobalControl.Instance.datas[0].data_1_2.wrong = quizManager.incorrectCount;
		}
		else if (i == "Level_1-3")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager1_3>();
			GlobalControl.Instance.datas[0].data_1_3.lvlPass = true;
			GlobalControl.Instance.datas[0].data_1_3.correct = quizManager.correctCount;
			GlobalControl.Instance.datas[0].data_1_3.wrong = quizManager.incorrectCount;
		}
		else if (i == "Level_2-1")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager2_1>();
			GlobalControl.Instance.datas[0].data_2_1.lvlPass = true;
			GlobalControl.Instance.datas[0].data_2_1.correct = quizManager.correctCount;
			GlobalControl.Instance.datas[0].data_2_1.wrong = quizManager.incorrectCount;
		}
		else if (i == "Level_2-2")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager2_2>();
			GlobalControl.Instance.datas[0].data_2_2.lvlPass = true;
			GlobalControl.Instance.datas[0].data_2_2.correct = quizManager.correctCount;
			GlobalControl.Instance.datas[0].data_2_2.wrong = quizManager.incorrectCount;
		}
		else if (i == "Level_2-3")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager2_3>();
			GlobalControl.Instance.datas[0].data_2_3.lvlPass = true;
			GlobalControl.Instance.datas[0].data_2_3.correct = quizManager.correctCount;
			GlobalControl.Instance.datas[0].data_2_3.wrong = quizManager.incorrectCount;
		}
		else if (i == "Level_3-1")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager3_1>();
			GlobalControl.Instance.datas[0].data_3_1.lvlPass = true;
			GlobalControl.Instance.datas[0].data_3_1.correct = quizManager.correctCount;
			GlobalControl.Instance.datas[0].data_3_1.wrong = quizManager.incorrectCount;
		}
		else if (i == "Level_3-2")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager3_2>();
			GlobalControl.Instance.datas[0].data_3_2.lvlPass = true;
			GlobalControl.Instance.datas[0].data_3_2.correct = quizManager.correctCount;
			GlobalControl.Instance.datas[0].data_3_2.wrong = quizManager.incorrectCount;
		}
		else if (i == "Level_3-3")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager3_3>();
			GlobalControl.Instance.datas[0].data_3_3.lvlPass = true;
			GlobalControl.Instance.datas[0].data_3_3.correct = quizManager.correctCount;
			GlobalControl.Instance.datas[0].data_3_3.wrong = quizManager.incorrectCount;
		}
		else if (i == "Level_4-1")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager4_1>();
			GlobalControl.Instance.datas[0].data_4_1.lvlPass = true;
			GlobalControl.Instance.datas[0].data_4_1.correct = quizManager.correctCount;
			GlobalControl.Instance.datas[0].data_4_1.wrong = quizManager.incorrectCount;
		}
		else if (i == "Level_4-2")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager4_2>();
			GlobalControl.Instance.datas[0].data_4_2.lvlPass = true;
			GlobalControl.Instance.datas[0].data_4_2.correct = quizManager.correctCount;
			GlobalControl.Instance.datas[0].data_4_2.wrong = quizManager.incorrectCount;
		}
		else if (i == "Level_Boss")
		{
			var quizManager = quizManagerGO.GetComponent<QuizManager_Boss>();
			GlobalControl.Instance.datas[0].data_boss.lvlPass = true;
			GlobalControl.Instance.datas[0].data_boss.correct = quizManager.correctCount;
			GlobalControl.Instance.datas[0].data_boss.wrong = quizManager.incorrectCount;
		}
	}
	
}