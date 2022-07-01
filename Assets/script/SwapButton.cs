using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapButton : MonoBehaviour
{
    public SquareCount Count1;
    public SquareCount Count2;

    public void swapValue()
    {
        Debug.Log(Count2.SumValue +"///"+ Count2.acceptValue * 10);
        if (Count2.count >= 10)
        {
            Count2.SumValue -= Count2.acceptValue * 10;
            Count2.SumValue = System.Math.Round(Count2.SumValue,2);
                if (Count2.SumValue > 0 && Count2.SumValue < 1)
                {
                    Count2.SumValue = System.Math.Round(Count2.SumValue, 2);
                }
            Count2.count -= 10;
            if(Count2.count <= 10)
            {
                for (int i = 9;i >= Count2.count; i--)
                    {
                    Count2.CatPic[i].SetActive(false);
                    }
            }

            Count1.SumValue += Count1.acceptValue;
            Count1.count += 1;
            if (Count1.count <= 10)
            {
                    Count1.CatPic[Count1.count - 1].SetActive(true);
            }
            Count1.setText();
            Count2.setText();
        }
        if (Count1.swapbutton != null)
        {
            Debug.Log("1NotNull");
            Count1.CheckSwapButton();
        }
        if (Count2.swapbutton != null)
        {
            Debug.Log("2NotNull");
            Count2.CheckSwapButton();
        }
    }
}
