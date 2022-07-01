using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    public GameObject MainMenu;
    public int save;

    public void Delete()
    {
        SaveSystem.DeletePlayer(save);
        MainMenu.GetComponent<MainMenu>().LoadWhenStartGame();
}
}
