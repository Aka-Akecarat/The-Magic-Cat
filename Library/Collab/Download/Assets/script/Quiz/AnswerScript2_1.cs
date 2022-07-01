using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerScript2_1 : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager2_1 quizManager;
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
