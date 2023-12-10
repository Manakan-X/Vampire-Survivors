using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public int[] moneyValues = { 5, 20, 50 };
    [SerializeField] PlayerStatus playerStatus;

    private void Start()
    {
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // 宝箱が開いてない且つ、接触したコライダーを持つゲームオブジェクトのタグがプレイヤーの場合
        if (col.CompareTag("Player"))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        int earnedMoney = GetRandomMoney();
        Debug.Log("Earned Money: " + earnedMoney);

        // お金をプレイヤーの資産に追加
        playerStatus.playerMoney += earnedMoney;

        Destroy(gameObject);
    }

    int GetRandomMoney()
    {
        if (moneyValues.Length == 0)
        {
            Debug.LogError("Money array is empty!");
            return 0;
        }

        int randomIndex = Random.Range(0, moneyValues.Length);
        return moneyValues[randomIndex];
    }
}
