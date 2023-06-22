using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probability : IMasterData
{
    public float OnDenominator { get { return Denominator; } }


    const float Denominator = 129;//確率分母
}
