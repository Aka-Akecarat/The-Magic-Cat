using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillManager : MonoBehaviour
{
    public GameObject nextScene;
    public InputField answerField;
    public Button answerButton;
    public List<Question> QnA;
    public int QIndex = 0;
    string ans;
    public GameObject correctPanel;
    public GameObject wrongPanel;
    public Text QuestionText;
    public Image[] CircleImage;

    // Start is called before the first frame update
    void Start()
    {


        QuestionText.text = QnA[QIndex].Questiontext;
        var se = new InputField.SubmitEvent();
        se.AddListener(GetAnswer);
        answerField.onEndEdit = se;
        answerField.Select();
        foreach (Image i in CircleImage)
        {
           i.sprite = QnA[QIndex].CircleImage;
        }
    }

    public void GetAnswer(string arg0)
    {
        Debug.Log(arg0);
        ans = (arg0);
    }

    public void CheckAnswer()
    {
        if(float.Parse(QnA[QIndex].Answer)  == float.Parse(ans))
        {
            StartCoroutine(correct());
            Debug.Log(true);
        }
        else
        {
            StartCoroutine(wrong());
            Debug.Log(false);
        }
    }

    public void setQuestion()
    {
        QuestionText.text = QnA[QIndex].Questiontext;
        foreach (Image i in CircleImage)
        {
            i.sprite = QnA[QIndex].CircleImage;

        }
    }

    IEnumerator correct()
    {
        correctPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        correctPanel.SetActive(false);
        if (QIndex + 1 < QnA.Count)
        {
            QIndex += 1;
        } else if (QIndex + 1 == QnA.Count)
        {
            nextScene.SetActive(true);
        }
        yield return null;
        answerField.text = "";
        setQuestion();
    }

    IEnumerator wrong()
    {
        wrongPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        answerField.text = "";
        wrongPanel.SetActive(false);
    }
}
