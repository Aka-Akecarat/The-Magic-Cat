using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class QuizManager1_3 : MonoBehaviour
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

    private void Start()
    {
        randomQuestion();
        generateQuestion();
        correctCountText.text = correctCount.ToString();
        incorrectCountText.text = incorrectCount.ToString();
    }

    public bool correct()
    {
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
            options[i].GetComponent<AnswerScript1_3>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answer[i];
            
            if(QnA[currentQuestion].CorrectAnswer == double.Parse(QnA[currentQuestion].Answer[i]))
            {
                options[i].GetComponent<AnswerScript1_3>().isCorrect = true;
            }
        }
    }

    void randomQuestion()
    {
        
        for (int i = 0; i < QnA.Count; i++)
        {
            A = System.Math.Round(Random.Range(0.00f, 9.99f), 2);
            B = System.Math.Round(Random.Range(0.00f, 9.99f), 2);

            double[] Answer = new double[4];
            //set right answer
            Answer[0] = (A + B);
            
            //random answer
            for (int a = 1; a < Answer.Length;a++)
                {
                   var _genAnswer = System.Math.Round(Random.Range(0.00f, 9.99f), 2);
                for (int x = 0; x < Answer.Length; x++)
                    {
                        while (Answer.Contains(_genAnswer))
                        {
                        _genAnswer = System.Math.Round(Random.Range(0.00f, 9.99f), 2);

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

                    // QnA[i].Answer[0] = (A_Int + B_Int).ToString();
                    // QnA[i].CorrectAnswer = QnA[i].CorrectAnswer +1;
                }

                // Get flaot. (might need it)
                //double b= (double) Mathf.Round(Random.Range(0.00f, 9.99f) * 100.0f) * 0.01f;
            QnA[i].a = A;
            QnA[i].b = B;
            QnA[i].CorrectAnswer = QnA[i].a + QnA[i].b;
            QnA[i].Question = A.ToString() + " + " + B.ToString() + " มีค่าเท่ากับเท่าไหร่";
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
