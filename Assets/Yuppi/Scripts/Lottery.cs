using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lottery : MonoBehaviour
{
    private bool firsthit = false; //��������
    private bool reach = false;  //���[�`���ۂ�

    [SerializeField]
    private int randomMaxP;�@//��������m��
    
    private int lostMax = 100; //�͂��ꎞ�̐U�蕪��

    private int reachNumber = 0;


    public void LooLetStart()
    {
       �@int randomP = Random.Range(1, randomMaxP);



        //Debug.Log("�X�^�[�g");
        if (randomP == 1)
        {
            firsthit = true;
            Debug.Log("������");

            int reachCount = Random.Range(1, 7);
            reachNumber = reachCount;//���[�`�e���p�C�̐���ۑ�
            Debug.Log(reachCount);

        }
        else
        {
            int lost = Random.Range(0, lostMax);

            if (lost < 10 )
            {
                reach = true; //���[�`
                Debug.Log("���[�`");

                int reachCount = Random.Range(1, 6);
                reachNumber = reachCount;//���[�`�e���p�C�̐���ۑ�
                Debug.Log(reachCount);

                int reachP = Random.Range(1, 100);
                if (reachP < 10)
                {
                    Debug.Log("���傢��");
                }
                else if(reachP < 100)
                {
                    Debug.Log("�t���[�Y");
                }

            }



            Debug.Log("�͂���");
        }

    }

}
