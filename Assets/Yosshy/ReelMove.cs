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

    bool IsReel = false;
    bool IsAction = false;

    private void Start()
    {
        pos = transform.localPosition.x;
        SetUp();
        
    }

    public void ReachAction(int index)
    {
        if (IsAction) { return; }

        IsAction = true;
        ReelActionUp.Pause();
        ReelActionDown.Pause();

        Reach(index);
    }

    public void ReelAction()
    {
        if (IsReel) { return; }

        IsReel = true;
        ReelActionCenter.Play();
        ReelActionDown.Play();
        ReelActionUp.Play();
    }

    public void Hazure()
    {
        if (IsAction) { return; }

        IsAction = true;
        ReelActionCenter.Pause();
        ReelActionDown.Pause();
        ReelActionUp.Pause();

        OnMove(Up, 0);
        OnMove(Under, 0.5f);
        OnMove(Center, 0.8f);
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

        ReelActionUp.Pause();
        ReelActionDown.Pause();
        ReelActionCenter.Pause();
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
               .Append(Up.DOLocalMoveX(-20, 0))
               .Append(Up.DOLocalMoveX(upindex + 3, Speed + 0.25f).SetEase(Ease.Linear))
               .Append(Up.DOLocalMoveX(upindex, 1).SetEase(Ease.Linear));

        DOTween.Sequence()
               .Append(Under.DOLocalMoveX(-20, 0))
               .Append(Under.DOLocalMoveX(downindex + 3, Speed + 0.35f).SetEase(Ease.Linear))
               .Append(Under.DOLocalMoveX(downindex, 1.3f).SetEase(Ease.Linear))
               .OnComplete(() => {IsAction = false; IsReel = false; });

    }

    private void OnMove(Transform reel,float duration)
    {
        var a = reel.localPosition.x - 3;
        DOTween.Sequence()
               .Append(reel.DOLocalMoveX((int)a, 1 + duration).SetEase(Ease.Linear))
               .OnComplete(() => { IsAction = false; IsReel = false; });


    }



}
