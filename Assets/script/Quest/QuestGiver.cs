using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Text titleText;
    public Text descText;
    public Quest quest;
    public Animator animator;
    public GlobalControl gb;

    void Update()
    {
        if (animator.GetBool("closeQuest")== false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(CloseQuestAfterTime());
            }
        }
            
    }
    private void Awake()
    {
        OpenQuest();
    }
    public void OpenQuest()
    {
        titleText.text = quest.title;
        descText.text = quest.description;
    }

    public void OpenQuestPanel()
    {
        if (animator.GetBool("closeQuest"))
        {
            animator.SetBool("closeQuest", false);
        }
        else
        {
            animator.SetBool("closeQuest", true);
        }
    }
    IEnumerator CloseQuestAfterTime()
    {
        yield return new WaitForSeconds(3f);
        animator.SetBool("closeQuest", true);
    }
}
