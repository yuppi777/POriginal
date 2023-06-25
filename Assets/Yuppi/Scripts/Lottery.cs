using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lottery : MonoBehaviour
{
    private bool firsthit = false; //初当たり
    private bool reach = false;  //リーチか否か

    [SerializeField]
    private int randomMaxP;　//初当たり確率
    
    private int lostMax = 100; //はずれ時の振り分け

    private int reachNumber = 0;


    public void LooLetStart()
    {
       　int randomP = Random.Range(1, randomMaxP);



        //Debug.Log("スタート");
        if (randomP == 1)
        {
            firsthit = true;
            Debug.Log("あたり");

            int reachCount = Random.Range(1, 7);
            reachNumber = reachCount;//リーチテンパイの数を保存
            Debug.Log(reachCount);

        }
        else
        {
            int lost = Random.Range(0, lostMax);

            if (lost < 10 )
            {
                reach = true; //リーチ
                Debug.Log("リーチ");

                int reachCount = Random.Range(1, 6);
                reachNumber = reachCount;//リーチテンパイの数を保存
                Debug.Log(reachCount);

                int reachP = Random.Range(1, 100);
                if (reachP < 10)
                {
                    Debug.Log("ちょい圧");
                }
                else if(reachP < 100)
                {
                    Debug.Log("フリーズ");
                }

            }



            Debug.Log("はずれ");
        }

    }

}
