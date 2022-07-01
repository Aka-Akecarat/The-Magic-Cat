using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

	public Text nameText;
	public Slider hpSlider;
	public Gradient gradient;
	public Image fill;

	public void SetHUD(Unit unit)
	{
		nameText.text = unit.unitName;
		hpSlider.maxValue = unit.maxHP;
		hpSlider.value = unit.currentHP;

		fill.color = gradient.Evaluate(1f);
	}

	public void SetHP(int hp)
	{
		hpSlider.value = hp;
		fill.color = gradient.Evaluate(hpSlider.normalizedValue);
	}

}
