using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutDestroy : MonoBehaviour
{
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
        }
    }
}
