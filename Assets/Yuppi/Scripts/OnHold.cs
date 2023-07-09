using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OnHold : MonoBehaviour
{

    public List<bool> onHoldCount = new List<bool>();

    public int maxHold = 4;

    public void RemoveOnHold()
    {
        onHoldCount.Remove(onHoldCount.First());
    }
}
