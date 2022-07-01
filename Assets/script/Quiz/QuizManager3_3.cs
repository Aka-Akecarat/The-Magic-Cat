﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class QuizManager3_3 : MonoBehaviour
{
    double A;
    double B;
    public List<QuestionAndAnswer1_3> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public GameObject quizManagerGO;

    public Text QuestionTxt;
    public TextMeshProUGUI correctCountText;
    public TextMeshProUGUI incorrectCountText;
    public int correctCount = 0;
    public int incorrectCount = 0;
    public BattleSystem battleSystem;
    public Weapon weapon;

    public Countdown CDTime;
    public Button hintButton;
    private void Start()
    {
        randomQuestion();
        generateQuestion();
        correctCountText.text = correctCount.ToString();
        incorrectCountText.text = incorrectCount.ToString();
    }

    public bool correct()
    {
        foreach (var o in options)
        {
            o.GetComponent<Button>().interactable = true;
        }
        hintButton = GameObject.FindGameObjectWithTag("Hint").GetComponent<Button>();
        hintButton.interactable = true;
        CDTime.timeStart = 10;
        correctCount += 1;
        correctCountText.text = correctCount.ToString();
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        quizManagerGO.SetActive(false);
        StartCoroutine(battleSystem.RightAns());
        battleSystem.Attack();
        return true;
    }
    public bool incorrect()
    {
        CDTime.timeStart = 10;
        incorrectCount += 1;
        incorrectCountText.text = incorrectCount.ToString();
        quizManagerGO.SetActive(false);
        StartCoroutine(battleSystem.EnemyTurn());
        return false;
    }

    void setAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript3_3>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answer[i];

            if (System.Math.Round(QnA[currentQuestion].CorrectAnswer, 2) == System.Math.Round(double.Parse(QnA[currentQuestion].Answer[i]), 2))
            {
                options[i].GetComponent<AnswerScript3_3>().isCorrect = true;
            }
        }
    }

    void randomQuestion()
    {
        for (int i = 0; i < QnA.Count; i++)
        {
            A = System.Math.Round(Random.Range(0.00f, 9.99f), 2);
            B = System.Math.Round(Random.Range(0.0f, 9.9f), 1);
            if (B > A)
            {
                var temp = B;
                B = A;
                A = temp;
            }
            double[] Answer = new double[4];
            //set right answer
            Answer[0] = (A * B);
            Answer[0] = System.Math.Round(Answer[0], 3);
            //random answer
            for (int a = 1; a < Answer.Length;a++)
                {
                   var _genAnswer = System.Math.Round(Random.Range(0.000f, 9.999f), 3);
                for (int x = 0; x < Answer.Length; x++)
                    {
                        while (Answer.Contains(_genAnswer))
                        {
                        _genAnswer = System.Math.Round(Random.Range(0.000f, 9.999f), 3);

                    }
                    }
                    Answer[a] = _genAnswer;
                }
                //shuffle answer
                for (int q = 0; q < Answer.Length; q++)
                {
                    int rnd = Random.Range(0, Answer.Length);
                    var temp = Answer[rnd];
                    Answer[rnd] = Answer[q];
                    Answer[q] = temp;
                }
            //put answer in
            for (int j = 0; j < QnA[i].Answer.Length; j++)
                {
                    QnA[i].Answer[j] = (Answer[j]).ToString();
                }
            QnA[i].a = A;
            QnA[i].b = B;
            QnA[i].CorrectAnswer = QnA[i].a * QnA[i].b;
            QnA[i].Question = A.ToString() + " X " + B.ToString() + " มีค่าเท่ากับเท่าไหร่";
            QnA[i].CorrectAnswer = System.Math.Round(QnA[i].CorrectAnswer, 3);
        }
    }
    void generateQuestion()
    {
        
        if (QnA.Count > 0) 
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            setAnswer();
        }
        else
        {
            Debug.Log("Out of Question");
        }
    }
}
