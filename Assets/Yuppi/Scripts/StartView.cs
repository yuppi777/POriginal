using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartView : MonoBehaviour
{





    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("���I�J�n");

        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("���I�J�n");
            Destroy(collision.gameObject);
        }

       
    }

}
