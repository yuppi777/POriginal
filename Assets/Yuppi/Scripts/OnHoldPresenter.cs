using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class OnHoldPresenter : MonoBehaviour
{
    [SerializeField]
    OnHold onHold;
    [SerializeField]
    OnHoldView holdView;

    void Start()
    {
        onHold.ObserveEveryValueChanged(tinpo => tinpo.onHoldCount.Count)
             .Subscribe(value =>
             {
                 holdView.SetHold(value);
             })
             .AddTo(this);
    }

   
}
