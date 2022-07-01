using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class QuizManager_Boss : MonoBehaviour
{
    //Qna[0] = int + int  // Qna[0].Qna1[i] = int + int
    //Qna[1] = int - int  // Qna[0].Qna2[i] = double + int
    //Qna[2] = int * int  // Qna[0].Qna3[i] = double + double
    //Qna[3] = int / int
    public List<QuestionAndAnswer_Boss> QnA;
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

    int Op;
    public string ListName;

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
        if (ListName == "Qna1")
        {
            QnA[Op].Qna1.RemoveAt(currentQuestion);
        }
        else if (ListName == "Qna2")
        {
            QnA[Op].Qna2.RemoveAt(currentQuestion);
        }
        if (ListName == "Qna3")
        {
            QnA[Op].Qna3.RemoveAt(currentQuestion);
        }
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

            options[i].GetComponent<AnswerScript_Boss>().isCorrect = false;
            if (ListName == "Qna1")
            {
                options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[Op].Qna1[currentQuestion].Answer[i];

                if (System.Math.Round((double)(QnA[Op].Qna1[currentQuestion].CorrectAnswer),2) == double.Parse(QnA[Op].Qna1[currentQuestion].Answer[i]))
                {
                    options[i].GetComponent<AnswerScript_Boss>().isCorrect = true;
                }
            }
            else if (ListName == "Qna2")
            {
                options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[Op].Qna2[currentQuestion].Answer[i];

                if (System.Math.Round((double)(QnA[Op].Qna2[currentQuestion].CorrectAnswer), 2) == System.Math.Round(double.Parse(QnA[Op].Qna2[currentQuestion].Answer[i]), 2))
                {
                    options[i].GetComponent<AnswerScript_Boss>().isCorrect = true;
                }
            }
            if (ListName == "Qna3")
            {
                options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[Op].Qna3[currentQuestion].Answer[i];

                if (System.Math.Round((double)(QnA[Op].Qna3[currentQuestion].CorrectAnswer), 2) == System.Math.Round(double.Parse(QnA[Op].Qna3[currentQuestion].Answer[i]), 2))
                {
                    options[i].GetComponent<AnswerScript_Boss>().isCorrect = true;
                }
            }
           
        }
    }

    void randomQuestion()
    {
        // int + int
        for (int i = 0; i < QnA[0].Qna1.Count; i++)//how many Question
        {
            var A_Int = Random.Range(0, 9);
            var B_Int = Random.Range(0, 9);

            int[] Answer = new int[4];
            //set right answer
            Answer[0] = (A_Int + B_Int);

            //random answer
            for (int a = 1; a < Answer.Length; a++)
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
            for (int j = 0; j < QnA[0].Qna1[i].Answer.Length; j++)
            {
                QnA[0].Qna1[i].Answer[j] = (Answer[j]).ToString();
            }
            QnA[0].Qna1[i].a = A_Int;
            QnA[0].Qna1[i].b = B_Int;
            QnA[0].Qna1[i].CorrectAnswer = QnA[0].Qna1[i].a + QnA[0].Qna1[i].b;
            QnA[0].Qna1[i].Question = A_Int.ToString() + " + " + B_Int.ToString() + " มีค่าเท่ากับเท่าไหร่";
        }
        // end int + int
        // double + int
        for (int i = 0; i < QnA[0].Qna2.Count; i++)
        {
            var A = Random.Range(0, 9);
            var B = System.Math.Round(Random.Range(0.00f, 9.99f), 2);

            double[] Answer = new double[4];
            //set right answer
            Answer[0] = (A + B);

            //random answer
            for (int a = 1; a < Answer.Length; a++)
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
            for (int j = 0; j < QnA[0].Qna2[i].Answer.Length; j++)
            {
                QnA[0].Qna2[i].Answer[j] = (Answer[j]).ToString();
            }
            QnA[0].Qna2[i].a = A;
            QnA[0].Qna2[i].b = B;
            QnA[0].Qna2[i].CorrectAnswer = QnA[0].Qna2[i].a + QnA[0].Qna2[i].b;
            QnA[0].Qna2[i].Question = A.ToString() + " + " + B.ToString() + " มีค่าเท่ากับเท่าไหร่";
        }

        // end double + int
        // double + double

        for (int i = 0; i < QnA[0].Qna3.Count; i++)
        {
            var A = System.Math.Round(Random.Range(0.00f, 9.99f), 2);
            var B = System.Math.Round(Random.Range(0.00f, 9.99f), 2);

            double[] Answer = new double[4];
            //set right answer
            Answer[0] = (A + B);

            //random answer
            for (int a = 1; a < Answer.Length; a++)
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
            for (int j = 0; j < QnA[0].Qna3[i].Answer.Length; j++)
            {
                QnA[0].Qna3[i].Answer[j] = (Answer[j]).ToString();

                // QnA[i].Answer[0] = (A_Int + B_Int).ToString();
                // QnA[i].CorrectAnswer = QnA[i].CorrectAnswer +1;
            }

            // Get flaot. (might need it)
            //double b= (double) Mathf.Round(Random.Range(0.00f, 9.99f) * 100.0f) * 0.01f;
            QnA[0].Qna3[i].a = A;
            QnA[0].Qna3[i].b = B;
            QnA[0].Qna3[i].CorrectAnswer = QnA[0].Qna3[i].a + QnA[0].Qna3[i].b;
            QnA[0].Qna3[i].Question = A.ToString() + " + " + B.ToString() + " มีค่าเท่ากับเท่าไหร่";
        }

        // end double + double
        // int - int

        for (int i = 0; i < QnA[1].Qna1.Count; i++)
        {
            var A_Int = Random.Range(0, 9);
            var B_Int = Random.Range(0, 9);
            if (B_Int > A_Int)
            {
                var temp = B_Int;
                B_Int = A_Int;
                A_Int = temp;
            }

            int[] Answer = new int[4];
            //set right answer
            Answer[0] = (A_Int - B_Int);

            //random answer
            for (int a = 1; a < Answer.Length; a++)
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
            for (int j = 0; j < QnA[1].Qna1[i].Answer.Length; j++)
            {
                QnA[1].Qna1[i].Answer[j] = (Answer[j]).ToString();

                // QnA[i].Answer[0] = (A_Int + B_Int).ToString();
                // QnA[i].CorrectAnswer = QnA[i].CorrectAnswer +1;
            }

            // Get flaot. (might need it)
            //double b= (double) Mathf.Round(Random.Range(0.00f, 9.99f) * 100.0f) * 0.01f;
            QnA[1].Qna1[i].a = A_Int;
            QnA[1].Qna1[i].b = B_Int;
            QnA[1].Qna1[i].CorrectAnswer = QnA[1].Qna1[i].a - QnA[1].Qna1[i].b;
            QnA[1].Qna1[i].Question = A_Int.ToString() + " - " + B_Int.ToString() + " มีค่าเท่ากับเท่าไหร่";
        }

        // end int - int //
        // double - int //

        for (int i = 0; i < QnA[1].Qna2.Count; i++)
        {
            var A = Random.Range(0, 9);
            var B = System.Math.Round(Random.Range(0.00f, 9.99f), 2);



            double[] Answer = new double[4];
            //set right answer
            if (B > A)
            {
                Answer[0] = (B - A);
            }
            else
            {
                Answer[0] = (A - B);
            }
            Answer[0] = System.Math.Round(Answer[0], 2);
            //random answer
            for (int a = 1; a < Answer.Length; a++)
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
            for (int j = 0; j < QnA[1].Qna2[i].Answer.Length; j++)
            {
                QnA[1].Qna2[i].Answer[j] = (Answer[j]).ToString();

                // QnA[i].Answer[0] = (A_Int + B_Int).ToString();
                // QnA[i].CorrectAnswer = QnA[i].CorrectAnswer +1;
            }

            // Get flaot. (might need it)
            //double b= (double) Mathf.Round(Random.Range(0.00f, 9.99f) * 100.0f) * 0.01f;

            QnA[1].Qna2[i].a = A;
            QnA[1].Qna2[i].b = B;
            if (B > A)
            {
                QnA[1].Qna2[i].CorrectAnswer = QnA[1].Qna2[i].b - QnA[1].Qna2[i].a;
                QnA[1].Qna2[i].Question = B.ToString() + " - " + A.ToString() + " มีค่าเท่ากับเท่าไหร่";
            }
            else
            {
                QnA[1].Qna2[i].CorrectAnswer = QnA[1].Qna2[i].a - QnA[1].Qna2[i].b;
                QnA[1].Qna2[i].Question = A.ToString() + " - " + B.ToString() + " มีค่าเท่ากับเท่าไหร่";
            }
            System.Math.Round(QnA[1].Qna2[i].CorrectAnswer, 2);
        }

        // end double - int //
        // double - double //

        for (int i = 0; i < QnA[1].Qna3.Count; i++)
        {
            var A = System.Math.Round(Random.Range(0.00f, 9.99f), 2);
            var B = System.Math.Round(Random.Range(0.00f, 9.99f), 2);

            if (B > A)
            {
                var temp = B;
                B = A;
                A = temp;
            }
            double[] Answer = new double[4];
            //set right answer
            Answer[0] = (A - B);
            Answer[0] = System.Math.Round(Answer[0], 2);
            //random answer
            for (int a = 1; a < Answer.Length; a++)
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
            for (int j = 0; j < QnA[1].Qna3[i].Answer.Length; j++)
            {
                QnA[1].Qna3[i].Answer[j] = (Answer[j]).ToString();
            }
            QnA[1].Qna3[i].a = A;
            QnA[1].Qna3[i].b = B;
            QnA[1].Qna3[i].CorrectAnswer = QnA[1].Qna3[i].a - QnA[1].Qna3[i].b;
            QnA[1].Qna3[i].Question = A.ToString() + " - " + B.ToString() + " มีค่าเท่ากับเท่าไหร่";
        }

        // end double - double //
        // int * int //

        for (int i = 0; i < QnA[2].Qna1.Count; i++)
        {
            var A_Int = Random.Range(0, 9);
            var B_Int = Random.Range(0, 9);
            if (B_Int > A_Int)
            {
                var temp = B_Int;
                B_Int = A_Int;
                A_Int = temp;
            }

            int[] Answer = new int[4];
            //set right answer
            Answer[0] = (A_Int * B_Int);

            //random answer
            for (int a = 1; a < Answer.Length; a++)
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
            for (int j = 0; j < QnA[2].Qna1[i].Answer.Length; j++)
            {
                QnA[2].Qna1[i].Answer[j] = (Answer[j]).ToString();
            }
            QnA[2].Qna1[i].a = A_Int;
            QnA[2].Qna1[i].b = B_Int;
            QnA[2].Qna1[i].CorrectAnswer = QnA[2].Qna1[i].a * QnA[2].Qna1[i].b;
            QnA[2].Qna1[i].Question = A_Int.ToString() + " X " + B_Int.ToString() + " มีค่าเท่ากับเท่าไหร่";
        }

        // end int * int //
        // double * int //

        for (int i = 0; i < QnA[2].Qna2.Count; i++)
        {
            var A = Random.Range(0, 9);
            var B = System.Math.Round(Random.Range(0.00f, 9.99f), 2);
            double[] Answer = new double[4];
            //set right answer
            Answer[0] = (A * B);
            Answer[0] = System.Math.Round(Answer[0], 2);
            //random answer
            for (int a = 1; a < Answer.Length; a++)
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
            for (int j = 0; j < QnA[2].Qna2[i].Answer.Length; j++)
            {
                QnA[2].Qna2[i].Answer[j] = (Answer[j]).ToString();
            }
            QnA[2].Qna2[i].a = A;
            QnA[2].Qna2[i].b = B;
            QnA[2].Qna2[i].CorrectAnswer = QnA[2].Qna2[i].a * QnA[2].Qna2[i].b;
            QnA[2].Qna2[i].Question = A.ToString() + " X " + B.ToString() + " มีค่าเท่ากับเท่าไหร่";
            QnA[2].Qna2[i].CorrectAnswer = System.Math.Round(QnA[2].Qna2[i].CorrectAnswer, 2);
        }

        // end double * int //
        // double * double //

        for (int i = 0; i < QnA[2].Qna3.Count; i++)
        {
            var A = System.Math.Round(Random.Range(0.00f, 9.99f), 2);
            var B = System.Math.Round(Random.Range(0.00f, 9.99f), 2);
            if (B > A)
            {
                var temp = B;
                B = A;
                A = temp;
            }
            double[] Answer = new double[4];
            //set right answer
            Answer[0] = (A * B);
            Answer[0] = System.Math.Round(Answer[0], 2);
            //random answer
            for (int a = 1; a < Answer.Length; a++)
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
            for (int j = 0; j < QnA[2].Qna3[i].Answer.Length; j++)
            {
                QnA[2].Qna3[i].Answer[j] = (Answer[j]).ToString();
            }
            QnA[2].Qna3[i].a = A;
            QnA[2].Qna3[i].b = B;
            QnA[2].Qna3[i].CorrectAnswer = QnA[2].Qna3[i].a * QnA[2].Qna3[i].b;
            QnA[2].Qna3[i].Question = A.ToString() + " X " + B.ToString() + " มีค่าเท่ากับเท่าไหร่";
            QnA[2].Qna3[i].CorrectAnswer = System.Math.Round(QnA[2].Qna3[i].CorrectAnswer, 2);
        }

        // end double * double //
        // int / int //

        for (int i = 0; i < QnA[3].Qna2.Count; i++)
        {
            int A_Int = Random.Range(1, 9);
            double B_Int = Random.Range(1, 9);
            double[] Answer = new double[4];
            //set right answer
            Answer[0] = (A_Int / B_Int);
            Answer[0] = System.Math.Round(Answer[0], 2);
            //random answer
            for (int a = 1; a < Answer.Length; a++)
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
                double temp = Answer[rnd];
                Answer[rnd] = Answer[q];
                Answer[q] = temp;
            }
            //put answer in
            for (int j = 0; j < QnA[3].Qna2[i].Answer.Length; j++)
            {
                QnA[3].Qna2[i].Answer[j] = (Answer[j]).ToString();
            }
            QnA[3].Qna2[i].a = A_Int;
            QnA[3].Qna2[i].b = B_Int;
            QnA[3].Qna2[i].CorrectAnswer = (double)QnA[3].Qna2[i].a / QnA[3].Qna2[i].b;
            QnA[3].Qna2[i].Question = A_Int.ToString() + " ÷ " + B_Int.ToString() + " มีค่าเท่ากับเท่าไหร่";

            QnA[3].Qna2[i].CorrectAnswer = System.Math.Round((double)QnA[3].Qna2[i].CorrectAnswer, 2);
        }

        // end int / int //
        // double / int //

        for (int i = 0; i < QnA[3].Qna3.Count; i++)
        {
            double A = System.Math.Round(Random.Range(1.00f, 9.99f), 2);
            double B = Random.Range(1, 9);
            double[] Answer = new double[4];
            //set right answer
                Answer[0] = (A / B);
            Answer[0] = System.Math.Round(Answer[0], 2);
            //random answer
            for (int a = 1; a < Answer.Length; a++)
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
            for (int j = 0; j < QnA[3].Qna3[i].Answer.Length; j++)
            {
                QnA[3].Qna3[i].Answer[j] = (Answer[j]).ToString();
            }
            QnA[3].Qna3[i].a = A;
            QnA[3].Qna3[i].b = B;

            decimal xd = (decimal)(A / B);
            Debug.Log(xd + " xd");
            QnA[3].Qna3[i].CorrectAnswer = A / B;
                QnA[3].Qna3[i].Question = A.ToString() + " ÷ " + B.ToString() + " มีค่าเท่ากับเท่าไหร่";
            QnA[3].Qna3[i].CorrectAnswer = System.Math.Round(QnA[3].Qna3[i].CorrectAnswer, 2);
        }
    }
    void generateQuestion()
    {
        if (QnA[0].Qna1.Count > 0) 
        {
            Op = 0 ;
            ListName = "Qna1";
            currentQuestion = Random.Range(0, QnA[0].Qna1.Count);
            QuestionTxt.text = QnA[0].Qna1[currentQuestion].Question;
            setAnswer();
        }
        else if (QnA[0].Qna2.Count > 0)
        {
            Op = 0;
            ListName = "Qna2";
            currentQuestion = Random.Range(0, QnA[0].Qna2.Count);

            QuestionTxt.text = QnA[0].Qna2[currentQuestion].Question;
            setAnswer();
        }
        else if (QnA[0].Qna3.Count > 0)
        {
            Op = 0;
            ListName = "Qna3";
            currentQuestion = Random.Range(0, QnA[0].Qna3.Count);

            QuestionTxt.text = QnA[0].Qna3[currentQuestion].Question;
            setAnswer();
        }
        else if (QnA[1].Qna1.Count > 0)
        {
            Op = 1;
            ListName = "Qna1";
            currentQuestion = Random.Range(0, QnA[1].Qna1.Count);
            QuestionTxt.text = QnA[1].Qna1[currentQuestion].Question;
            setAnswer();
        }
        else if (QnA[1].Qna2.Count > 0)
        {
            Op = 1;
            ListName = "Qna2";
            currentQuestion = Random.Range(0, QnA[1].Qna2.Count);
            QuestionTxt.text = QnA[1].Qna2[currentQuestion].Question;
            setAnswer();
        }
        else if (QnA[1].Qna3.Count > 0)
        {
            Op = 1;
            ListName = "Qna3";
            currentQuestion = Random.Range(0, QnA[1].Qna3.Count);

            QuestionTxt.text = QnA[1].Qna3[currentQuestion].Question;
            setAnswer();
        }
        else if (QnA[2].Qna1.Count > 0)
        {
            Op = 2;
            ListName = "Qna1";
            currentQuestion = Random.Range(0, QnA[2].Qna1.Count);
            QuestionTxt.text = QnA[2].Qna1[currentQuestion].Question;
            setAnswer();
        }
        else if (QnA[2].Qna2.Count > 0)
        {
            Op = 2;
            ListName = "Qna2";
            currentQuestion = Random.Range(0, QnA[2].Qna2.Count);
            QuestionTxt.text = QnA[2].Qna2[currentQuestion].Question;
            setAnswer();
        }
        else if (QnA[2].Qna3.Count > 0)
        {
            Op = 2;
            ListName = "Qna3";
            currentQuestion = Random.Range(0, QnA[2].Qna3.Count);

            QuestionTxt.text = QnA[2].Qna3[currentQuestion].Question;
            setAnswer();
        }
        else if (QnA[3].Qna1.Count > 0)
        {
            Op = 3;
            ListName = "Qna1";
            currentQuestion = Random.Range(0, QnA[3].Qna1.Count);
            QuestionTxt.text = QnA[3].Qna1[currentQuestion].Question;
            setAnswer();
        }
        else if (QnA[3].Qna2.Count > 0)
        {
            Op = 3;
            ListName = "Qna2";
            currentQuestion = Random.Range(0, QnA[3].Qna2.Count);
            QuestionTxt.text = QnA[3].Qna2[currentQuestion].Question;
            setAnswer();
        }
        else if (QnA[3].Qna3.Count > 0)
        {
            Op = 3;
            ListName = "Qna3";
            currentQuestion = Random.Range(0, QnA[3].Qna3.Count);
            QuestionTxt.text = QnA[3].Qna3[currentQuestion].Question;
            setAnswer();
        }
        else
        {
            Debug.Log("Out of Question");
        }
    }
}
