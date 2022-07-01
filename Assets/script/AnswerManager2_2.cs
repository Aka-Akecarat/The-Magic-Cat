using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerManager2_2 : MonoBehaviour
{
    public SquareCount SquareCount1;
    public SquareCount SquareCount01;
    public SquareCount SquareCount001;
    public double answer;
    public Text QuestionTest;
    public GameObject CorrectCanvas;
    public GameObject IncorrectCanvas;
    public GameObject Go;
    public GameObject Guide;
    double A_Int;
    double B_Int;

    private void Start()
    {
        GenerateQuestion();
        GlobalControl.Instance.LastSceneName = SceneManager.GetActiveScene().name;
        GlobalControl.Instance.NextSceneName = "coin5";
        if (GlobalControl.Instance.BoxPass == true)
        {
            Go.SetActive(true);
            Guide.SetActive(false);
        }
    }

    public void GenerateQuestion()
    {
        Debug.Log(10.25 % 1);
        Debug.Log((A_Int % 1 * 10) - Mathf.Floor((float)(A_Int % 1 * 10)));

        A_Int = Random.Range(0, 9);
        B_Int = System.Math.Round(Random.Range(0.00f, 9.99f), 2);
        if (B_Int > A_Int)
        {
            var temp = B_Int;
            B_Int = A_Int;
            A_Int = temp;
        }

        double x = A_Int % 1;
        Debug.Log(System.Math.Round(x,2));
        x = x * 10;
        Debug.Log(x);
        x = System.Math.Round(x - (double)Mathf.Floor((float)x), 2);
        x = x / 10;
        Debug.Log(x);

        //set cat image
        SquareCount1.SumValue = (int)Mathf.Floor((float)A_Int);
        SquareCount1.count = (int)Mathf.Floor((float)A_Int);
        SquareCount1.setText();

        SquareCount01.SumValue = System.Math.Round((A_Int % 1) - x,2);
        SquareCount01.count = (int)System.Math.Round((((A_Int % 1) - x) *10), 2);
        SquareCount01.setText();

        SquareCount001.SumValue = x;
        SquareCount001.count = (int)System.Math.Round((x * 100), 2);
        SquareCount001.setText();

        for (int i = 0; i <= A_Int - 1; i++)//1
        {
            SquareCount1.CatPic[i].SetActive(true);
        }
        for (int i = 0; i <= SquareCount01.count - 1; i++)//0.1
        {
            SquareCount01.CatPic[i].SetActive(true);
        }
        for (int i = 0; i <= SquareCount001.count - 1; i++)//0.01 (x)
        {
            SquareCount001.CatPic[i].SetActive(true);
        }

        QuestionTest.text = A_Int + " - " + B_Int + " มีค่าเท่ากับเท่าไหร่";
    }
    void GetAnswer()
    {
        answer = SquareCount1.SumValue + SquareCount01.SumValue + SquareCount001.SumValue;
    }

    public void CheckAnswer()
    {
        GetAnswer();
            A_Int = System.Math.Round(A_Int, 2);
            B_Int = System.Math.Round(B_Int, 2);
            answer = System.Math.Round(answer, 2);
            double x = A_Int - B_Int;
            x = System.Math.Round(x, 2);
        Debug.Log(x);
        Debug.Log(answer);
            if (answer == x)
            {
                Debug.Log("Correct");
                StartCoroutine(correct());
            }
            else
            {
                Debug.Log("InCorrect");
                StartCoroutine(wrong());
            }
    }

    IEnumerator correct()
    {
        CorrectCanvas.SetActive(true);
        yield return new WaitForSeconds(2f);
        CorrectCanvas.SetActive(false);
        ResetGame();
        GenerateQuestion();
        if (GlobalControl.Instance.BoxPass == false)
        {
            GlobalControl.Instance.BoxPass = true;
            AskB4Go();
        }
        else
        {
            Go.SetActive(true);
        }
    }

    IEnumerator wrong()
    {
        IncorrectCanvas.SetActive(true);
        yield return new WaitForSeconds(2f);
        IncorrectCanvas.SetActive(false);
    }

    private void ResetGame()
    {
        for(int i=0; i<= SquareCount1.CatPic.Length-1; i++) 
        {
            SquareCount1.CatPic[i].SetActive(false);
            SquareCount1.OutsideCatPic[i].SetActive(false);
            SquareCount01.CatPic[i].SetActive(false);
            SquareCount01.OutsideCatPic[i].SetActive(false);
            SquareCount001.CatPic[i].SetActive(false);
            SquareCount001.OutsideCatPic[i].SetActive(false);
        }
            SquareCount1.SumValue = 0;
            SquareCount1.count = 0;
            SquareCount1.outsideCount = 0;
            SquareCount1.setText();
            SquareCount01.SumValue = 0;
            SquareCount01.count = 0;
            SquareCount01.outsideCount = 0;
            SquareCount01.setText();
            SquareCount001.SumValue = 0;
            SquareCount001.count = 0;
            SquareCount001.outsideCount = 0;
            SquareCount001.setText();
    }

    public void AskB4Go()
    {
        SceneManager.LoadScene("AskBeforeGo");
    }
    public void OpenGuide()
    {
        Guide.SetActive(true);
    }
}
