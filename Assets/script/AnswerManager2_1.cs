using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerManager2_1 : MonoBehaviour
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
    int B_Int;

    private void Start()
    {
        GenerateQuestion();
        GlobalControl.Instance.LastSceneName = SceneManager.GetActiveScene().name;
        GlobalControl.Instance.NextSceneName = "coin4";
        if (GlobalControl.Instance.BoxPass == true)
        {
            Go.SetActive(true);
            Guide.SetActive(false);
        }
    }

    public void GenerateQuestion()
    {
        A_Int = Random.Range(0, 9);
        B_Int = Random.Range(0, 9);
        if (B_Int > A_Int)
        {
            var temp = B_Int;
            B_Int = A_Int;
            A_Int = temp;
        }
        //set cat image
        SquareCount1.SumValue = A_Int;
        SquareCount1.count = A_Int;
        SquareCount1.setText();
        SquareCount01.SumValue = 0;
        SquareCount01.count = 0;
        SquareCount01.setText();
        SquareCount001.SumValue = 0;
        SquareCount001.count = 0;
        SquareCount001.setText();

        for (int i = 0; i <= A_Int - 1; i++)
        {
            SquareCount1.CatPic[i].SetActive(true);
            SquareCount01.CatPic[i].SetActive(false);
            SquareCount001.CatPic[i].SetActive(false);
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
            if (answer == A_Int - B_Int)
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
        for (int i = 0; i <= SquareCount1.CatPic.Length - 1; i++)
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
