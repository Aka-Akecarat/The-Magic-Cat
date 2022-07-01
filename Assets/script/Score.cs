using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text p1;
    public Text p2;
    public Text p3;
    public Text m1;
    public Text m2;
    public Text m3;
    public Text mu1;
    public Text mu2;
    public Text mu3;
    public Text d1;
    public Text d2;
    public Text d3;
    public Text SumP;
    public Text SumM;
    public Text SumMu;
    public Text SumD;

    public Text gp1;
    public Text gp2;
    public Text gp3;
    public Text gm1;
    public Text gm2;
    public Text gm3;
    public Text gmu1;
    public Text gmu2;
    public Text gmu3;
    public Text gd1;
    public Text gd2;
    public Text gd3;
    public Text gSumP;
    public Text gSumM;
    public Text gSumMu;
    public Text gSumD;


    public LevelLoader levelLoader;
    void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer(GlobalControl.Instance.saveID);
        //-------------------------------nightmare---------------------------------------//
        GlobalControl.Instance.datas[0].data_1_1.lvlPass = data.datas[0].data_1_1.lvlPass;
        GlobalControl.Instance.datas[0].data_1_1.correct = data.datas[0].data_1_1.correct;
        GlobalControl.Instance.datas[0].data_1_1.wrong = data.datas[0].data_1_1.wrong;
        GlobalControl.Instance.datas[0].data_1_2.lvlPass = data.datas[0].data_1_2.lvlPass;
        GlobalControl.Instance.datas[0].data_1_2.correct = data.datas[0].data_1_2.correct;
        GlobalControl.Instance.datas[0].data_1_2.wrong = data.datas[0].data_1_2.wrong;
        GlobalControl.Instance.datas[0].data_1_3.lvlPass = data.datas[0].data_1_3.lvlPass;
        GlobalControl.Instance.datas[0].data_1_3.correct = data.datas[0].data_1_3.correct;
        GlobalControl.Instance.datas[0].data_1_3.wrong = data.datas[0].data_1_3.wrong;

        GlobalControl.Instance.datas[0].data_2_1.lvlPass = data.datas[0].data_2_1.lvlPass;
        GlobalControl.Instance.datas[0].data_2_1.correct = data.datas[0].data_2_1.correct;
        GlobalControl.Instance.datas[0].data_2_1.wrong = data.datas[0].data_2_1.wrong;
        GlobalControl.Instance.datas[0].data_2_2.lvlPass = data.datas[0].data_2_2.lvlPass;
        GlobalControl.Instance.datas[0].data_2_2.correct = data.datas[0].data_2_2.correct;
        GlobalControl.Instance.datas[0].data_2_2.wrong = data.datas[0].data_2_2.wrong;
        GlobalControl.Instance.datas[0].data_2_3.lvlPass = data.datas[0].data_2_3.lvlPass;
        GlobalControl.Instance.datas[0].data_2_3.correct = data.datas[0].data_2_3.correct;
        GlobalControl.Instance.datas[0].data_2_3.wrong = data.datas[0].data_2_3.wrong;

        GlobalControl.Instance.datas[0].data_3_1.lvlPass = data.datas[0].data_3_1.lvlPass;
        GlobalControl.Instance.datas[0].data_3_1.correct = data.datas[0].data_3_1.correct;
        GlobalControl.Instance.datas[0].data_3_1.wrong = data.datas[0].data_3_1.wrong;
        GlobalControl.Instance.datas[0].data_3_2.lvlPass = data.datas[0].data_3_2.lvlPass;
        GlobalControl.Instance.datas[0].data_3_2.correct = data.datas[0].data_3_2.correct;
        GlobalControl.Instance.datas[0].data_3_2.wrong = data.datas[0].data_3_2.wrong;
        GlobalControl.Instance.datas[0].data_3_3.lvlPass = data.datas[0].data_3_3.lvlPass;
        GlobalControl.Instance.datas[0].data_3_3.correct = data.datas[0].data_3_3.correct;
        GlobalControl.Instance.datas[0].data_3_3.wrong = data.datas[0].data_3_3.wrong;

        GlobalControl.Instance.datas[0].data_4_1.lvlPass = data.datas[0].data_4_1.lvlPass;
        GlobalControl.Instance.datas[0].data_4_1.correct = data.datas[0].data_4_1.correct;
        GlobalControl.Instance.datas[0].data_4_1.wrong = data.datas[0].data_4_1.wrong;
        GlobalControl.Instance.datas[0].data_4_2.lvlPass = data.datas[0].data_4_2.lvlPass;
        GlobalControl.Instance.datas[0].data_4_2.correct = data.datas[0].data_4_2.correct;
        GlobalControl.Instance.datas[0].data_4_2.wrong = data.datas[0].data_4_2.wrong;
        GlobalControl.Instance.datas[0].data_boss.lvlPass = data.datas[0].data_boss.lvlPass;
        GlobalControl.Instance.datas[0].data_boss.correct = data.datas[0].data_boss.correct;
        GlobalControl.Instance.datas[0].data_boss.wrong = data.datas[0].data_boss.wrong;
        //-------------------------------nightmare---------------------------------------//


        var x = GlobalControl.Instance.datas[0];

        if (x.data_1_1.correct + x.data_1_1.wrong == 0) { p1.text = "0%"; } 
            else 
        {
            var a = (x.data_1_1.correct / (x.data_1_1.correct + x.data_1_1.wrong) * 100);
            p1.text = System.Math.Round(a, 2).ToString() + "%";
            setGrade(a, gp1);
        }
        if (x.data_1_2.correct + x.data_1_2.wrong == 0) { p2.text = "0%"; }
            else 
        {
            var a = (x.data_1_2.correct / (x.data_1_2.correct + x.data_1_2.wrong) * 100);
            p2.text = System.Math.Round(a, 2).ToString() + "%";
            setGrade(a, gp2);
        }
        if (x.data_1_3.correct + x.data_1_3.wrong == 0) { p3.text = "0%"; }
            else 
        {
            var a = (x.data_1_3.correct / (x.data_1_3.correct + x.data_1_3.wrong) * 100);
            p3.text = System.Math.Round(a, 2).ToString() + "%";
            setGrade(a, gp3);
        }
        if (x.data_2_1.correct + x.data_2_1.wrong == 0) { m1.text = "0%"; }
            else 
        {
            var a = (x.data_2_1.correct / (x.data_2_1.correct + x.data_2_1.wrong) * 100);
            m1.text = System.Math.Round(a, 2).ToString() + "%";
            setGrade(a, gm1);
        }
        if (x.data_2_2.correct + x.data_2_2.wrong == 0) { m2.text = "0%"; }
            else 
        {
            var a = (x.data_2_2.correct / (x.data_2_2.correct + x.data_2_2.wrong) * 100);
            m2.text = System.Math.Round(a, 2).ToString() + "%";
            setGrade(a, gm2);
        }
        if (x.data_2_3.correct + x.data_2_3.wrong == 0) { m3.text = "0%"; }
            else 
        {
            var a = (x.data_2_3.correct / (x.data_2_3.correct + x.data_2_3.wrong) * 100);
            m3.text = System.Math.Round(a, 2).ToString().ToString() + "%";
            setGrade(a, gm3);
        }
        if (x.data_3_1.correct + x.data_3_1.wrong == 0) { mu1.text = "0%"; }
            else 
        {
            var a = (x.data_3_1.correct / (x.data_3_1.correct + x.data_3_1.wrong) * 100);
            mu1.text = System.Math.Round(a, 2).ToString().ToString() + "%";
            setGrade(a, gmu1);
        }
        if (x.data_3_2.correct + x.data_3_2.wrong == 0) { mu2.text = "0%"; }
            else 
        {
            var a = (x.data_3_2.correct / (x.data_3_2.correct + x.data_3_2.wrong) * 100);
            mu2.text = System.Math.Round(a, 2).ToString().ToString() + "%";
            setGrade(a, gmu2);
        }
        if (x.data_3_3.correct + x.data_3_3.wrong == 0) { mu3.text = "0%"; }
            else 
        {
            var a = (x.data_3_3.correct / (x.data_3_3.correct + x.data_3_3.wrong) * 100);
            mu3.text = System.Math.Round(a, 2).ToString() + "%";
            setGrade(a, gmu3);
        }
        if (x.data_4_1.correct + x.data_4_1.wrong == 0) { d1.text = "0%"; }
            else 
        {
            var a = (x.data_4_1.correct / (x.data_4_1.correct + x.data_4_1.wrong) * 100);
            d1.text = System.Math.Round(a, 2).ToString() + "%";
            setGrade(a, gd1);
        }
        if (x.data_4_2.correct + x.data_4_2.wrong == 0) { d2.text = "0%"; }
            else 
        {
            var a = (x.data_4_2.correct / (x.data_4_2.correct + x.data_4_2.wrong) * 100);
            d2.text = System.Math.Round(a, 2).ToString() + "%";
            setGrade(a, gd2);
        }
        if (x.data_boss.correct + x.data_boss.wrong == 0) { d3.text = "0%"; }
            else 
        {
            var a = (x.data_boss.correct / (x.data_boss.correct + x.data_boss.wrong) * 100);
            d3.text = System.Math.Round(a, 2).ToString() + "%";
            setGrade(a, gd3);
        }

        var sp = ((x.data_1_1.correct / (x.data_1_1.correct + x.data_1_1.wrong) * 100)
           + (x.data_1_2.correct / (x.data_1_2.correct + x.data_1_2.wrong) * 100)
           + (x.data_1_3.correct / (x.data_1_3.correct + x.data_1_3.wrong) * 100)) / 3;
        if (double.IsNaN(sp))
        {
            SumP.text = "0%";
        }
        else
        {
            SumP.text = System.Math.Round(sp, 2).ToString() + "%";
            setGrade(sp,gSumP);
        }
        var sm = ((x.data_2_1.correct / (x.data_2_1.correct + x.data_2_1.wrong) * 100)
           + (x.data_2_2.correct / (x.data_2_2.correct + x.data_2_2.wrong) * 100)
           + (x.data_2_3.correct / (x.data_2_3.correct + x.data_2_3.wrong) * 100)) / 3;
        if (double.IsNaN(sm))
        {
            SumM.text = "0%";
        }
        else
        {
            SumM.text = System.Math.Round(sm, 2).ToString() + "%";
            setGrade(sm, gSumM);
        }
        var smu = ((x.data_3_1.correct / (x.data_3_1.correct + x.data_3_1.wrong) * 100)
           + (x.data_3_2.correct / (x.data_3_2.correct + x.data_3_2.wrong) * 100)
           + (x.data_3_3.correct / (x.data_3_3.correct + x.data_3_3.wrong) * 100)) / 3;
        if (double.IsNaN(smu))
        {
            SumMu.text = "0%";
        }
        else
        {
            SumMu.text = System.Math.Round(smu, 2).ToString() + "%";
            setGrade(smu, gSumMu);
        }
        var sd = ((x.data_4_1.correct / (x.data_4_1.correct + x.data_4_1.wrong) * 100)
           + (x.data_4_2.correct / (x.data_4_2.correct + x.data_4_2.wrong) * 100)
           + (x.data_boss.correct / (x.data_boss.correct + x.data_boss.wrong) * 100)) / 3;
        if (double.IsNaN(sd))
        {
            SumD.text = "0%";
        }
        else
        {
            SumD.text = System.Math.Round(sd, 2).ToString() + "%";
            setGrade(sd, gSumD);
        }
    }

    public void endGame()
    {
        levelLoader.LoadNextLevel("MainMenu");
    }

    public void setGrade(double x, Text text)
    {
        if(x>=0 && x <= 49)
        {
            text.text = "0";
        }
        else if (x >= 50 && x <= 54)
        {
            text.text = "1";
        }
        else if (x >= 55 && x <= 59)
        {
            text.text = "1.5";
        }
        else if (x >= 60 && x <= 64)
        {
            text.text = "2";
        }
        else if (x >= 65 && x <= 69)
        {
            text.text = "2.5";
        }
        else if (x >= 70 && x <= 74)
        {
            text.text = "3";
        }
        else if (x >= 75 && x <= 79)
        {
            text.text = "3.5";
        }
        else if (x >= 80 && x <= 100)
        {
            text.text = "4";
        }
    }
}
