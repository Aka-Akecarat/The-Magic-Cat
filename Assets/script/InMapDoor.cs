using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMapDoor : MonoBehaviour
{
    public GameObject Lock;
    public GameObject Unlock;
    public GameObject Pass;

    public void SetDoor_Pass()
    {
            Lock.SetActive(false);
            Unlock.SetActive(false);
            Pass.SetActive(true);
    }
    public void SetDoor_Unlock()
    {
        Lock.SetActive(false);
        Unlock.SetActive(true);
        Pass.SetActive(false);
    }
    public void SetDoor_Lock()
    {
        Lock.SetActive(true);
        Unlock.SetActive(false);
        Pass.SetActive(false);
    }
}
