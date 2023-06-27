using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using JetBrains.Annotations;

public class ReelMove : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] Transform Up;
    [SerializeField] Transform Under;
    [SerializeField] Transform Center;
    Sequence ReelActionCenter = null;
    Sequence ReelActionUp = null;
    Sequence ReelActionDown = null;
    float pos;
    int i;

    private void Start()
    {
        pos = transform.localPosition.x;
        SetUp();
        Observable.EveryUpdate().Where(i => Input.GetKeyDown(KeyCode.W))
            .Subscribe(l => 
            { 
                ReelActionCenter.Pause(); 
                ReelActionDown.Pause(); 
                ReelActionUp.Pause(); 

                OnMove(Up,0); 
                OnMove(Under,0.5f); 
                OnMove(Center,0.8f); 
            });
        
        Observable.EveryUpdate().Where(i => Input.GetKeyDown(KeyCode.Q))
            .Subscribe(l => 
            {
                ReelActionCenter.Play();
                ReelActionDown.Play();
                ReelActionUp.Play();
            }); 
        
        Observable.EveryUpdate().Where(i => Input.anyKeyDown)
            .Where(x => int.TryParse(Input.inputString,out i))
            .Subscribe(l => 
            {
                ReelActionUp.Pause();
                ReelActionDown.Pause();

                Reach(i);
            }); 
    }

    public void SetUp()
    {

        ReelActionCenter = DOTween.Sequence()
               .Append(Center.DOLocalMoveX(pos - 14, Speed + 0.08f).SetEase(Ease.Linear))
               .OnComplete(() => ReelActionCenter.Restart());

        ReelActionUp = DOTween.Sequence()
               .Append(Up.DOLocalMoveX(pos - 14, Speed +0.05f).SetEase(Ease.Linear))
               .OnComplete(() => ReelActionUp.Restart());

        ReelActionDown = DOTween.Sequence()
               .Append(Under.DOLocalMoveX(pos - 14, Speed+0.04f).SetEase(Ease.Linear))
               .OnComplete(() => ReelActionDown.Restart());
               

    }

    public void Reach(int index)
    {
        var upindex = 0;
        var downindex = 0;

        switch (index)
        {
            case 1:
                upindex = -13;
                downindex = -15;
                break;
            case 2:
                upindex = -11;
                downindex = -3;
                break;
            case 3:
                upindex = -9;
                downindex = -5;
                break;
            case 4:
                upindex = -7;
                downindex = -7;
                break;
            case 5:
                upindex = -5;
                downindex = -9;
                break;
            case 6:
                upindex = -3;
                downindex = -11;
                break;
            case 7:
                upindex = -15;
                downindex = -13;
                break;
        }

        DOTween.Sequence()
               .Append(Up.DOLocalMoveX(-20,0))
               .Append(Up.DOLocalMoveX(upindex + 3, Speed + 0.25f).SetEase(Ease.Linear))
               .Append(Up.DOLocalMoveX(upindex, 1).SetEase(Ease.Linear));

        DOTween.Sequence()
               .Append(Under.DOLocalMoveX(-20, 0))
               .Append(Under.DOLocalMoveX(downindex + 3, Speed + 0.35f).SetEase(Ease.Linear))
               .Append(Under.DOLocalMoveX(downindex, 1.3f).SetEase(Ease.Linear));

    }

    private void OnMove(Transform reel,float duration)
    {
        var a = reel.localPosition.x - 3;
        DOTween.Sequence()
               .Append(reel.DOLocalMoveX((int)a, 1 + duration).SetEase(Ease.Linear));
    }



}
