using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class MainLogic
{
    /// <summary>
    /// 抽選
    /// </summary>
    public bool Lottery(float denom)
    {
        Random random = new Random();
        var index = random.Next(0,(int)denom);

        if(index == denom)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 外れ演出
    /// </summary>
    public int Performance(int value)
    {
        return 1;
    }


}
