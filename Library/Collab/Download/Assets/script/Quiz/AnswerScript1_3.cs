using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerScript1_3 : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager1_3 quizManager;
    public void Answer()
    {
        if (isCorrect)
        {
            
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Wromg Answer");
            quizManager.incorrect();
        }
    }
}
