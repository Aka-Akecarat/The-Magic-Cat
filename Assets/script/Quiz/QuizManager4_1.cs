using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class QuizManager4_1 : MonoBehaviour
{
    double A_Int;
    double B_Int;
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
            options[i].GetComponent<AnswerScript4_1>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answer[i];

            if (System.Math.Round(QnA[currentQuestion].CorrectAnswer, 2) == System.Math.Round(double.Parse(QnA[currentQuestion].Answer[i]), 2))
            {
                options[i].GetComponent<AnswerScript4_1>().isCorrect = true;
            }
        }
    }

    void randomQuestion()
    {
        for (int i = 0; i < QnA.Count; i++)
        {
            A_Int = Random.Range(1, 9);
            B_Int = Random.Range(1, 9); 
            if(B_Int > A_Int)
            {
                var temp = B_Int;
                B_Int = A_Int;
                A_Int = temp;
            }
            double[] Answer = new double[4];
            //set right answer
            Answer[0] = (A_Int / B_Int);
            Answer[0] = System.Math.Round(Answer[0], 2);
            //random answer
            for (int a = 1; a < Answer.Length;a++)
                {
                   var _genAnswer = Random.Range(0, 9);
                    for (int x = 0; x < Answer.Length; x++)
                    {
                        while (Answer.Contains(_genAnswer))
                        {
                        _genAnswer = Random.Range(0, 9);
                           
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
            QnA[i].a = A_Int;
            QnA[i].b = B_Int;
            QnA[i].CorrectAnswer = QnA[i].a / QnA[i].b;
            QnA[i].Question = A_Int.ToString() + " ÷ " + B_Int.ToString() + " มีค่าเท่ากับเท่าไหร่";

            QnA[i].CorrectAnswer = System.Math.Round(QnA[i].CorrectAnswer, 2);
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
