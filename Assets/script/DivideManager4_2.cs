using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DivideManager4_2 : MonoBehaviour
{
    public GameObject Go;
    public GameObject Guide;
    public Text QuestionText;
    public GameObject[] CatPic1;
    public GameObject[] CatPic01;
    public GameObject[] CatPic001;
    public GameObject[] DivideBasket;
    public double A;
    public double B;
    public GameObject CorrectCanvas;
    public GameObject IncorrectCanvas;
    double x;

    private void Start()
    {
        GlobalControl.Instance.LastSceneName = SceneManager.GetActiveScene().name;
        GlobalControl.Instance.NextSceneName = "coin11";
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
        double x = A % 1;
        Debug.Log(System.Math.Round(x, 2));
        x = x * 10;
        Debug.Log(x);
        x = System.Math.Round(x - (double)Mathf.Floor((float)x), 2);
        x = x / 10;
        Debug.Log(x);

        var a = (int)Mathf.Floor((float)A);
        var b = (int)System.Math.Round((((A % 1) - x) * 10), 2);
        var c = (int)System.Math.Round((x * 100), 2);

        Debug.Log(a);
        Debug.Log(b);
        Debug.Log(c);
        for (int i = 0; i < a; i++)
        {
            CatPic1[i].SetActive(true);
        }
        for (int i = 0; i < b; i++)
        {
            CatPic01[i].SetActive(true);
        }
        for (int i = 0; i < c; i++)
        {
            CatPic001[i].SetActive(true);
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
        A = System.Math.Round(Random.Range(0.01f, 9.99f), 2);
        B = Random.Range(1, 9);
        QuestionText.text = A + " ÷ " + B + " มีค่าเท่ากับเท่าไหร่";
        //DirectionText.text = "";
    }

    public void CheckAnswer()
    {
        x = 0;
        foreach (GameObject i in DivideBasket)
        {
            if(x <= i.GetComponent<DivideBasket>().value)
            {
                x = i.GetComponent<DivideBasket>().value;
            }
        }
        x = System.Math.Round(x, 2);
        Debug.Log("x = " + x);
        //x = x / B;
        x = System.Math.Round(x, 2);
        Debug.Log("x = " + x);
        Debug.Log("a/b = " + A/B);
        var y = System.Math.Round(A / B, 2);
        Debug.Log(x);
        Debug.Log(y);
        if ((x + 0.02 >= y && x - 0.02 <= y) || x == y)
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
        }
    }

    IEnumerator wrong()
    {
        IncorrectCanvas.SetActive(true);
        yield return new WaitForSeconds(2f);
        IncorrectCanvas.SetActive(false);
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
