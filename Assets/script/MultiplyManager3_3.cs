using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiplyManager3_3 : MonoBehaviour
{
    public GameObject Go;
    public GameObject Guide;
    public GameObject basket;
    public GameObject basket2;
    public GameObject[] aCanvas;
    public string[] DText;
    public int CanvasIndex;
    public CatGroup catGroup;
    public InsideCatGroup insideCatGroup;
    public double value;
    public int dotIndex;
    public Text QuestionText;
    public Text DirectionText;
    public Text NewQuestionText;
    public GameObject NewQuestionTextGO;
    public double A;
    public double B;
    public GameObject TipPanel;
    public GameObject CorrectCanvas;
    public GameObject IncorrectCanvas;
    
    public Text AText;
    public Text BText;
    public Button AButton;
    public Button BButton;
    public GameObject GoNextButton;

    public double AnsValue;
    public Text AnsText;
    public Button AnsButton;
    public GameObject AnsGoButton;
    private void Start()
    {
        GlobalControl.Instance.LastSceneName = SceneManager.GetActiveScene().name;
        GlobalControl.Instance.NextSceneName = "coin9";
        if (GlobalControl.Instance.BoxPass == true)
        {
            Go.SetActive(true);
            Guide.SetActive(false);
        }
        GenerateQuestion();
        CanvasIndex = 0;
        setText(CanvasIndex);
        if (A % 1 == 0 || B % 1 == 0)
        {
            if (A % 1 == 0)
            {
                AButton.interactable = false;
            }
            if (B % 1 == 0)
            {
                BButton.interactable = false;
            }
            GoNextButton.SetActive(true);
        }
    }
    public void GoNextScene()
    {
        System.Math.Round(basket.GetComponent<Busket>().value, 2);
        if (A % 1 != 0 && basket.GetComponent<Busket>().value == A )
        {
            Debug.Log(A % 1);
        }
        else if (B % 1 != 0 && basket.GetComponent<Busket>().value == B)
        {
            Debug.Log(B % 1);
        }
        if (basket.GetComponent<Busket>().value == A || basket.GetComponent<Busket>().value == B)
        {
            value = basket.GetComponent<Busket>().value;
            catGroup.value = value;

            ChangeScene();

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
        A = System.Math.Round(Random.Range(0.00f, 9.99f), 2);
        B = System.Math.Round(Random.Range(0.0f, 9.9f), 1);
        if (B > A)
        {
            var temp = B;
            B = A;
            A = temp;
        }
        QuestionText.text = A + " X " + B + " มีค่าเท่ากับเท่าไหร่";
        AText.text = A.ToString();
        BText.text = B.ToString();
    }

    public void CheckAnswer()
    {
        A = System.Math.Round(A, 2);
        B = System.Math.Round(B, 2);
        var ans = A * B;
        ans = System.Math.Round(ans, 2);
        if (basket2.GetComponent<Busket>().value == ans)
        {
            Debug.Log("Correct");
            StartCoroutine(correct());
            ChangeScene();
            AnsValue = ans;
            AnsText.text = ans.ToString();
            if (dotIndex == 0)
            {
                AnsButton.interactable = false;
                AnsGoButton.SetActive(true);
            }
        }
        else
        {
            Debug.Log("InCorrect");
            Debug.Log(A * B);
            StartCoroutine(wrong());
        }
    }
    IEnumerator correct()
    {
        CorrectCanvas.SetActive(true);
        yield return new WaitForSeconds(2f);
        CorrectCanvas.SetActive(false);
    }

    IEnumerator wrong()
    {
        IncorrectCanvas.SetActive(true);
        yield return new WaitForSeconds(2f);
        IncorrectCanvas.SetActive(false);
    }

    public void ChangeA_Value()
    {
        A *= 10;
        Debug.Log(A);
        A = System.Math.Round(A, 2);
        Debug.Log(A);
        Debug.Log(A%1);
        AText.text = A.ToString();
        dotIndex += 1;
        if (A % 1 == 0)
        {
            AButton.interactable = false;
            GoNextButton.SetActive(true);

        }
    }

    public void ChangeB_Value()
    {
        B *= 10;
        Debug.Log(B);
        B = System.Math.Round(B, 2);
        Debug.Log(B);
        Debug.Log(B%1);
        BText.text = B.ToString();
        dotIndex += 1;
        if (B % 1 == 0)
        {
            BButton.interactable = false;
            GoNextButton.SetActive(true);
        }
    }

    public void Change_Value()
    {
        AnsValue /= 10;
        Debug.Log(AnsValue);
        //value = System.Math.Round(value, 2);
        Debug.Log(value);
        Debug.Log(value % 1);
        AnsText.text = AnsValue.ToString();

        var ans = A * B;
        Debug.Log(ans);
        ans = ans / System.Math.Pow(10, dotIndex);
        Debug.Log(ans);
        ans = System.Math.Round(ans, 2);
        Debug.Log(ans);

        if (System.Math.Round(AnsValue, 2) == ans)
        {
            AnsButton.interactable = false;
            AnsGoButton.SetActive(true);
        }
    }
    public void CheckAnswer2()
    {
        var ans = A * B;
        Debug.Log(ans);
        ans = ans / System.Math.Pow(10, dotIndex);
        Debug.Log(ans);
        ans = System.Math.Round(ans, 2);
        Debug.Log(ans);
        if (System.Math.Round(AnsValue, 2) == ans)
        {
            Debug.Log("Correct");
            StartCoroutine(correct());
                GlobalControl.Instance.BoxPass = true;
                AskB4Go();


        }
        else
        {
            Debug.Log("InCorrect");
            System.Math.Round(AnsValue, 2);
            StartCoroutine(wrong());
        }
    }
    public void ChangeScene()
    {
        aCanvas[CanvasIndex].SetActive(false);
        CanvasIndex += 1;
        aCanvas[CanvasIndex].SetActive(true);
        setText(CanvasIndex);
        if (CanvasIndex == 1)
        {
            NewQuestionTextGO.SetActive(true);
            NewQuestionText.text = A + " x " + B;
        }
    }
    public void setText(int i)
    {
        DirectionText.text = DText[i];
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

