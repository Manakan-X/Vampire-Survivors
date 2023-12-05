using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int[] moneyValues = { 5, 20, 50 };

    int GetRandomMoney()
    {
        int randomIndex = Random.Range(0, moneyValues.Length);
        return moneyValues[randomIndex];
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // �����̃I�u�W�F�N�g�ɐN�����Ă����I�u�W�F�N�g���A�R���y�A�^�O"Player"�̏ꍇ
        if (col.CompareTag("Player"))
        {
            int earnedMoney = GetRandomMoney();
            Debug.Log("Earned Money: " + earnedMoney);
        }
    }
}
