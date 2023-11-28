using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int hp;
    public int exp;

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
            }
            Destroy(bullet.gameObject);
        }
    }
}
