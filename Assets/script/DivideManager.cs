using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DivideManager : MonoBehaviour
{
    public GameObject Go;
    public Text QuestionText;
    public GameObject[] CatPic1;
    public GameObject[] CatPic01;
    public GameObject[] CatPic001;
    public GameObject[] DivideBasket;
    public double A;
    public double B;
    public GameObject CorrectCanvas;
    public GameObject IncorrectCanvas;
    public GameObject Guide;

    double x;

    private void Start()
    {
        GlobalControl.Instance.LastSceneName = SceneManager.GetActiveScene().name;
        GlobalControl.Instance.NextSceneName = "coin10";
        if (GlobalControl.Instance.BoxPass == true)
        {
            Go.SetActive(true);
            Guide.SetActive(false);
        }
        foreach (GameObject i in DivideBasket)
        {
            i.GetComponent<DivideBasket>().valueText.gameObject.SetActive(false);
            i.SetActive(false);
        }
        GenerateQuestion();
        setCat();
        setBasket();
    }

    public void setCat()
    {
        for (int i = 0; i < A; i++)
        {

            CatPic1[i].SetActive(true);
        }
    }
    public void setBasket()
    {
        for (int i = 0; i < B; i++)
        {
            DivideBasket[i].SetActive(true);
            DivideBasket[i].GetComponent<DivideBasket>().valueText.gameObject.SetActive(true);
            DivideBasket[i].GetComponent<DivideBasket>().SetValueText();
        }
    }

    public void GenerateQuestion()
    {
        A = Random.Range(1, 9);
        B = Random.Range(1, 9);
        if (B > A)
        {
            var temp = B;
            B = A;
            A = temp;
        }
        QuestionText.text = A + " ÷ " + B + " มีค่าเท่ากับเท่าไหร่";
        //DirectionText.text = "";
    }

    public void CheckAnswer()
    {
        x = 0;
        foreach (GameObject i in DivideBasket)
        {
            if (x <= i.GetComponent<DivideBasket>().value)
            {
                x = i.GetComponent<DivideBasket>().value;
            }
        }
        x = System.Math.Round(x, 2);
        Debug.Log("x = " + x);
        //x = x / B;
        x = System.Math.Round(x, 2);
        Debug.Log("x = " + x);
        Debug.Log("a/b = " + A / B);
        var y = System.Math.Round(A / B, 2);
        Debug.Log(x);
        Debug.Log(y);
        if ((x + 0.02 >= y && x - 0.02 <= y )|| x == y)
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
        if (GlobalControl.Instance.BoxPass == false)
        {
            GlobalControl.Instance.BoxPass = true;
            AskB4Go();
        }
        else
        {
            Go.SetActive(true);
            GenerateQuestion();
            setCat();
            setBasket();
        }
    }

    IEnumerator wrong()
    {
        IncorrectCanvas.SetActive(true);
        yield return new WaitForSeconds(2f);
        IncorrectCanvas.SetActive(false);
    }

    public void OpenGuide()
    {
        Guide.SetActive(true);
    }
    public void AskB4Go()
    {
        SceneManager.LoadScene("AskBeforeGo");
    }
}
