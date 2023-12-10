using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] PlayerStatus playerStatus;

    public int enemyExp;
    public float moneyDropProbability = 0.1f;       // 10���̊m���ł������h���b�v
    public GameObject moneyPrefab;      // �����̃v���t�@�u

    private void Start()
    {
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            // �e�̍U���͂̕�����hp�����炷
            hp -= bullet.atackPower;

            // hp��0�ȉ��ɂȂ��Ă��邩�m�F����
            if (hp <= 0)
            {
                // hp��0�ȉ���������G��j�󂷂�
                Destroy(gameObject);

                // PlayerStatus��exp�ϐ���enemyExp�����Z
                playerStatus.exp += enemyExp;

                // �G���j�󂳂ꂽ����̊m���ł������h���b�v����
                if (Random.value < moneyDropProbability)
                {
                    DropMoney();
                }
            }
            Destroy(bullet.gameObject);
        }
    }

    void DropMoney()
    {
        Instantiate(moneyPrefab, transform.position, Quaternion.identity);
    }
}
