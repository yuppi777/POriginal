using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InstantiationBall : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private Transform instantiationPos;


    
    void Start()
    {
        OnInitialize();
    }

   private void OnInitialize()
   {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                BallInstantiation();
            }

        }).AddTo(this);
   }

   private void BallInstantiation()
   {
        Instantiate(ballPrefab, instantiationPos.position, Quaternion.identity);
   }

}
