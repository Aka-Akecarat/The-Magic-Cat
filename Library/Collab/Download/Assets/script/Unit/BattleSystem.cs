using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public GameObject quizManagerGO;
	public QuizManager quizManager;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	Unit playerUnit;
	Unit enemyUnit;

	public TextMeshProUGUI MoneyText;
	public GameObject hintCanvas;
	public GameObject guideCanvas;
	public GameObject[] guideImage;
	public int guideIndex = 0;

	public Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

	// Start is called before the first frame update
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
		dialogueText.text = "คุณตอบผิด";
		yield return new WaitForSeconds(1f);
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

	}

	public void OnCloseHintButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;
		hintCanvas.SetActive(false);

	}

	public void OnGuideButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;
		guideCanvas.SetActive(true);
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
		GlobalControl.Instance.currentHP = playerUnit.currentHP;
		GlobalControl.Instance.currentMoney = playerUnit.currentMoney+enemyUnit.currentMoney;
		var x = GlobalControl.Instance.currentMoney.ToString();
		MoneyText.text = x;
	}
	public void StartQuiz()
    {
        quizManagerGO.SetActive(true);
	}

}