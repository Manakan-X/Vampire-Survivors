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
        // �󔠂��J���ĂȂ����A�ڐG�����R���C�_�[�����Q�[���I�u�W�F�N�g�̃^�O���v���C���[�̏ꍇ
        if (col.CompareTag("Player"))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        int earnedMoney = GetRandomMoney();
        Debug.Log("Earned Money: " + earnedMoney);

        // �������v���C���[�̎��Y�ɒǉ�
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
