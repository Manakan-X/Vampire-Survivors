using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] PlayerStatus playerStatus;

    public int enemyExp;
    public float moneyDropProbability = 0.1f;       // 10％の確率でお金をドロップ
    public GameObject moneyPrefab;      // お金のプレファブ

    private void Start()
    {
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            // 弾の攻撃力の分だけhpを減らす
            hp -= bullet.atackPower;

            // hpが0以下になっているか確認する
            if (hp <= 0)
            {
                // hpが0以下だったら敵を破壊する
                Destroy(gameObject);

                // PlayerStatusのexp変数にenemyExpを加算
                playerStatus.exp += enemyExp;

                // 敵が破壊されたら一定の確率でお金をドロップする
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
