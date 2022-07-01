using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

	public string unitName;
	public float AttackTime = 0.1f;
	public int damage;

	public int maxHP;
	public int currentHP;

	public int currentMoney;

	public Animator animator;

	Weapon Weapon;
	void Awake()
	{
		animator = this.GetComponent<Animator>();
		Weapon = this.GetComponent<Weapon>();
	}
	public bool TakeDamage(int dmg)
	{
		currentHP -= dmg;

		if (currentHP <= 0)
			return true;
		else
			return false;
	}

	public void Heal(int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP)
			currentHP = maxHP;
	}
	public void Attack()
	{
		StartCoroutine(PlayAttack());
	}

    IEnumerator PlayAttack()
	{
		
		animator.SetBool("IsAttack", true);
		yield return new WaitForSeconds(AttackTime);
		if(Weapon != null)
        {
			Weapon.Shoot();
        }
		animator.SetBool("IsAttack", false);
	}

	public void SetPosition(float x, float y, float z)
    {
		transform.position.Set(x, y, z);

	}

}
