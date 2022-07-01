using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigntEnemy : MonoBehaviour
{
    public LevelLoader LevelLoader;
    public string LevelName;
    void OnTriggerEnter2D(Collider2D hitInfo)

    {
        Unit player = hitInfo.GetComponent<Unit>();
        if (player != null)
        {
            GlobalControl.Instance.position[0] = transform.position.x;
            GlobalControl.Instance.position[1] = transform.position.y;
            GlobalControl.Instance.position[2] = transform.position.z;
            LevelLoader.LoadNextLevel(LevelName);
        }
    }
}
