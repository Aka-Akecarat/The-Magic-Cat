using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerScript4_1 : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager4_1 quizManager;
    public void Answer()
    {
        if (isCorrect)
        {
            FindObjectOfType<AudioManager>().Play("Correct");
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Wrong");
            Debug.Log("Wromg Answer");
            quizManager.incorrect();
        }
    }
}
