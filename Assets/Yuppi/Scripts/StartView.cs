using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartView : MonoBehaviour
{





    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("抽選開始");

        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("抽選開始");
            Destroy(collision.gameObject);
        }

       
    }

}
