using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lottery : MonoBehaviour
{
    private bool firsthit = false; //初当たり
    private bool reach = false;  //リーチか否か

    [SerializeField]
    private int randomMaxP;
    [SerializeField]
    private ReelMove Move;
    [SerializeField]
    private OnHold onHold;
    
    private int lostMax = 100; //はずれ時の振り分け

    private int reachNumber = 0;

    private int[] rushNumbers = new int[] { 1, 3, 5, 7 };
    private int[] normalNumbers = new int[] { 2, 4, 6};


    public void LooLetStart()
    {
        int randomP = Random.Range(1, randomMaxP);


        if (onHold.onHoldCount.Count < onHold.maxHold)
        {
            Move.ReelAction();

            if (randomP ==1)
            {
                onHold.onHoldCount.Add(true);
            }
            else
            {
                onHold.onHoldCount.Add(false);
            }

        }
      


        //Debug.Log(A);
        if (randomP == 1)　//あたり
        {
            firsthit = true;
           
            if (onHold.onHoldCount.Count < onHold.maxHold) //保留がマックスになったら
            {
                Debug.Log("あたり");
                //onHold.onHoldCount.Add(true);
                DOTween.Sequence()
                    .AppendInterval(3)
                    .OnComplete(() => 
                    {
                        Move.ReachAction(reachNumber);
                        onHold.RemoveOnHold();
                    });
                    //.OnComplete(() => onHold.RemoveOnHold()); ;


                int rushjudge = Random.Range(1, 100);
                if (rushjudge < 50)
                {
                    int rushReachCount = Random.Range(0, rushNumbers.Length);
                    reachNumber = rushNumbers[rushReachCount];//リーチテンパイの数を保存
                    Debug.Log(rushNumbers[rushReachCount]);

                    Debug.Log("確変");
                }
                else if (rushjudge < 100)
                {
                    int normalReachCount = Random.Range(0, normalNumbers.Length);
                    reachNumber = normalNumbers[normalReachCount];//リーチテンパイの数を保存
                    Debug.Log(normalNumbers[normalReachCount]);
                    Debug.Log("通常");
                }

            }





        }
        else  //はずれ
        {
            if (onHold.onHoldCount.Count < onHold.maxHold)//保留がマックスになったら
            {

                //onHold.onHoldCount.Add(false);

                int lost = Random.Range(0, lostMax);

                if (lost < 10)
                {
                    reach = true; //リーチ
                    Debug.Log("リーチ");

                    int reachCount = Random.Range(1, 6);
                    reachNumber = reachCount;//リーチテンパイの数を保存
                    Debug.Log(reachCount);

                    DOTween.Sequence()
                           .AppendInterval(3)
                           .OnComplete(() => Move.ReachAction(reachNumber));
                          

                    int reachP = Random.Range(1, 100);
                    if (reachP < 10)
                    {
                        Debug.Log("好機");
                    }
                    else if (reachP < 20)
                    {
                        Debug.Log("フリーズ");
                    }

                }



                Debug.Log("はずれ");

                DOTween.Sequence()
                       .AppendInterval(3)
                       .OnComplete(() =>
                       {
                           Move.Hazure();
                           onHold.RemoveOnHold();
                       });
                       //.OnComplete(() =>
                       //{
                       //    onHold.RemoveOnHold();
                       //});
            }
           


        }

    }

}
