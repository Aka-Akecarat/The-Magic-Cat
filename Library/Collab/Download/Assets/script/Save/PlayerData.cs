using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
	public string unitName;

	public int maxHP;
	public int currentHP;
	public int currentMoney;
	public float[] position;

	public PlayerData(Unit unit)
    {
		if(unit.unitName == "แมวจอมเวทย์")
        {
			currentHP = unit.currentHP;
			currentMoney = unit.currentMoney;

			position = new float[3];
			position[0] = unit.transform.position.x;
			position[1] = unit.transform.position.y;
			position[2] = unit.transform.position.z;

		}
    }
}
