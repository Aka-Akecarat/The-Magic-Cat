using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    public Text nameText;
    public int saveID;
    public Button ScoreButton;
    public GameObject DeleteButton;
    public GameObject ThisButton;

    public void AskBeforeDelete()
    {
        DeleteButton.GetComponent<DeleteButton>().save = saveID;
    }
}
