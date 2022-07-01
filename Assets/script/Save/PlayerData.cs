using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
	public string unitName;

	public int saveID;
	public string saveName;
	public int maxHP;
	public int currentHP;
	public int currentMoney;
	public float[] position;
	public string BeforeSaveSceneName;
	public List<data> datas = new List<data>();
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

			saveID = GlobalControl.Instance.saveID;
			saveName = GlobalControl.Instance.saveName;
			datas = GlobalControl.Instance.datas;
			BeforeSaveSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
		}
    }
}
