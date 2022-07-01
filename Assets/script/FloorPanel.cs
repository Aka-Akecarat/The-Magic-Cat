using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorPanel : MonoBehaviour
{
    public Button[] floorButton;
    void Start()
    {
        setAvalableFloor();
    }

    public void setAvalableFloor()
    {
        floorButton[1].interactable = false;
        floorButton[2].interactable = false;
        floorButton[3].interactable = false;
        if (GlobalControl.Instance)
        {
            if(GlobalControl.Instance.datas[0].data_1_3.lvlPass == true)
            {
                floorButton[1].interactable = true;
            }
            if (GlobalControl.Instance.datas[0].data_2_3.lvlPass == true)
            {
                floorButton[2].interactable = true;
            }
            if (GlobalControl.Instance.datas[0].data_3_3.lvlPass == true)
            {
                floorButton[3].interactable = true;
            }
        }
    }
}
