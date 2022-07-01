using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerManager1_2 : MonoBehaviour
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
    int A_Int;
    double B_Int;

    private void Start()
    {
        GenerateQuestion();
        GlobalControl.Instance.LastSceneName = SceneManager.GetActiveScene().name;
        GlobalControl.Instance.NextSceneName = "coin2";
        if (GlobalControl.Instance.BoxPass == true)
        {
            Go.SetActive(true);
            Guide.SetActive(false);
        }
    }

    public void GenerateQuestion()
    {
        A_Int = Random.Range(1, 9);
        B_Int = System.Math.Round(Random.Range(0.01f, 9.99f), 2);

        QuestionTest.text = A_Int + " + " + B_Int + " มีค่าเท่ากับเท่าไหร่";
    }
    void GetAnswer()
    {
        answer = SquareCount1.SumValue + SquareCount01.SumValue + SquareCount001.SumValue;
        answer = System.Math.Round(answer, 2);
    }

    public void CheckAnswer()
    {
        GetAnswer();
        var x = A_Int + B_Int;
        x = System.Math.Round(x, 2);
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
        SquareCount1.SumValue = 0;
        SquareCount1.count = 0;
        SquareCount1.setText();
        SquareCount1.CatPic[i].SetActive(false);
        SquareCount01.SumValue = 0;
        SquareCount01.count = 0;
        SquareCount01.setText();
        SquareCount01.CatPic[i].SetActive(false);
        SquareCount001.SumValue = 0;
        SquareCount001.count = 0;
        SquareCount001.setText();
        SquareCount001.CatPic[i].SetActive(false);
        }
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
