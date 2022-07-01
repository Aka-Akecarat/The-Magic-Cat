using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuidePanel : MonoBehaviour
{
    public GameObject[] guide;
    public int guideIndex = 0;
    public Button close;

    public void NextImage()
    {
        if (guideIndex == 0)
        {
            guide[guideIndex].SetActive(true);
            guideIndex += 1;
        }
        else if (guideIndex < guide.Length)
        {
            guide[guideIndex].SetActive(true);
            guide[guideIndex -1].SetActive(false);
            guideIndex += 1;
        }else if (guideIndex == guide.Length)
        {
            guide[0].SetActive(true);
            guide[guideIndex - 1].SetActive(false);
            guideIndex = 1;
            close.interactable = true;
        }
    }

    public void closeGuide()
    {
        foreach(GameObject i in guide)
        {
            i.SetActive(false);
        }
        guide[0].SetActive(true);
        gameObject.SetActive(false);
    }
}
