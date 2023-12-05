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
        // お金のオブジェクトに侵入してきたオブジェクトが、コンペアタグ"Player"の場合
        if (col.CompareTag("Player"))
        {
            int earnedMoney = GetRandomMoney();
            Debug.Log("Earned Money: " + earnedMoney);
        }
    }
}
