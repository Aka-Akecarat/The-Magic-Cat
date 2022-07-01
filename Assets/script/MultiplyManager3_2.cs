using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiplyManager3_2 : MonoBehaviour
{
    public GameObject Guide;
    public GameObject Go;
    public GameObject basket;
    public GameObject basket2;
    public GameObject aCanvas;
    public GameObject bCanvas;
    public CatGroup catGroup;
    public InsideCatGroup insideCatGroup;
    public double value;
    public Text QuestionText;
    public Text DirectionText;
    double A;
    double B;
    public GameObject TipPanel;
    public GameObject CorrectCanvas;
    public GameObject IncorrectCanvas;

    private void Start()
    {
        GenerateQuestion();
        GlobalControl.Instance.LastSceneName = SceneManager.GetActiveScene().name;
        GlobalControl.Instance.NextSceneName = "coin8";
        if (GlobalControl.Instance.BoxPass == true)
        {
            Guide.SetActive(false);
        }
    }
    public void GoNextScene()
    {
        if(A % 1 != 0 && basket.GetComponent<Busket>().value == A )
        {
            Debug.Log(A % 1);
        }
        else if (B % 1 != 0 && basket.GetComponent<Busket>().value == B)
        {
            Debug.Log(B % 1);
        }
        if (basket.GetComponent<Busket>().value == A || basket.GetComponent<Busket>().value == B)
        {
            DirectionText.text = "ใส่กลุ่มจำนวนในตะกร้าให้เท่ากับตัวคูณของโจทย์ที่กำหนด";
            value = basket.GetComponent<Busket>().value;
            catGroup.value = value;
            aCanvas.SetActive(false);
            bCanvas.SetActive(true);
            Busket b = basket.GetComponent<Busket>();
            catGroup.value = value;
            for (int i = 0; i < b.CatPic1Count; i++)
            {
                catGroup.CatPic1[i].SetActive(true);
                insideCatGroup.CatPic1[i].SetActive(true);
            }
            for (int i = 0; i < b.CatPic01Count; i++)
            {
                catGroup.CatPic01[i].SetActive(true);
                insideCatGroup.CatPic01[i].SetActive(true);
            }
            for (int i = 0; i < b.CatPic001Count; i++)
            {
                catGroup.CatPic001[i].SetActive(true);
                insideCatGroup.CatPic001[i].SetActive(true);
            }
        }
        else
        {
            //TipPanel.SetActive(true);
            Debug.Log(basket.GetComponent<Busket>().value);
        }
    }
    public void GenerateQuestion()
    {
        A = Random.Range(1, 9);
        B = System.Math.Round(Random.Range(0.01f, 9.99f), 2);
        if (B % 1 != 0)
        {
            var temp = B;
            B = A;
            A = temp;
        }

        QuestionText.text = A + " X " + B + " มีค่าเท่ากับเท่าไหร่";
        //DirectionText.text = "";
    }

    public void CheckAnswer()
    {
        A = System.Math.Round(A, 2);
        B = System.Math.Round(B, 2);
        if (basket2.GetComponent<Busket>().value == A * B)
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
            GlobalControl.Instance.BoxPass = true;
            AskB4Go();
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

