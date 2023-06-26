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
            Debug.Log("’Š‘IŠJŽn");
            lottery.LooLetStart();
            Destroy(collision.gameObject);
        }

       
    }

}
