using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{

    private Rigidbody2D _thisBallRb;

    [SerializeField]
    private float speed;

   

    private Vector3 force;

    private Vector3 forceDirection;


    private void Awake()
    {

        try
        {
            _thisBallRb = this.gameObject.GetComponent<Rigidbody2D>();
        }
        catch (System.Exception)
        {
            this.gameObject.AddComponent<Rigidbody>();
            _thisBallRb = this.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    void Start()
    {
        BallAddForce();
    }

   private void BallAddForce()
    {
        forceDirection = new Vector3(3.7f, 10f, 0f);

        force = speed * Random.Range(0.1f,0.5f)   * forceDirection;
        //_thisBallRb.AddForce(this.gameObject.transform.right *-speed);
        _thisBallRb.AddForce(force, ForceMode2D.Impulse );
    }
}
