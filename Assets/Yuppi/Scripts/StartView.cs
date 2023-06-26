using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartView : MonoBehaviour
{

    [SerializeField]
    private Lottery lottery;



    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("抽選開始");
            lottery.LooLetStart();
            Destroy(collision.gameObject);
        }

       
    }

}
