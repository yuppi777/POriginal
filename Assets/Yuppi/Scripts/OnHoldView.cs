using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoldView : MonoBehaviour
{
    [SerializeField]
    List<GameObject> holds;

   
     public void SetHold(int holdCount)
     {
        for (int i = 0; i < holds.Count; i++)
        {
            GameObject hold = holds[i];
            hold.SetActive(holdCount > i);
        }

     }
}
