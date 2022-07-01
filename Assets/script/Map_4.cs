using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_4 : MonoBehaviour
{
    public InMapDoor inMapDoor_1;
    public InMapDoor inMapDoor_2;
    public InMapDoor inMapDoor_3;

    private void Start()
    {
        SetDoor();
    }

    public void SetDoor()
    {
        if(GlobalControl.Instance.datas[0].data_4_1.lvlPass == true)
        {
            inMapDoor_1.Lock.SetActive(false);
            inMapDoor_1.Unlock.SetActive(false);
            inMapDoor_1.Pass.SetActive(true);

            inMapDoor_2.Lock.SetActive(false);
            inMapDoor_2.Unlock.SetActive(true);
            inMapDoor_2.Pass.SetActive(false);
        }
        if (GlobalControl.Instance.datas[0].data_4_2.lvlPass == true)
        {
            inMapDoor_2.Lock.SetActive(false);
            inMapDoor_2.Unlock.SetActive(false);
            inMapDoor_2.Pass.SetActive(true);

            inMapDoor_3.Lock.SetActive(false);
            inMapDoor_3.Unlock.SetActive(true);
            inMapDoor_3.Pass.SetActive(false);
        }
        if (GlobalControl.Instance.datas[0].data_boss.lvlPass == true)
        {
            inMapDoor_3.Lock.SetActive(false);
            inMapDoor_3.Unlock.SetActive(false);
            inMapDoor_3.Pass.SetActive(true);
        }
    }
}
