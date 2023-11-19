using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// デフォルト
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;     // 弾速

    [SerializeField] private float destroyTime;     // 消滅までの時間

    public int atackPower;      // 弾の攻撃力

    /// <summary>
    /// バレット発射
    /// </summary>
    public void Shoot(Vector2 direction)
    {
        // このゲームオブジェクトにRigidbody2Dがアタッチされていれば、変数rbにRigidbody2Dを代入する
        if (TryGetComponent(out Rigidbody2D rb))
        {
            // direction(方向)とbulletSpeed(弾速)に基づいて、力を加えて発射する
            rb.AddForce(direction * bulletSpeed);
        }

        // 一定時間経過後、弾を消滅させる
        Destroy(gameObject, destroyTime);

        //弾の向きを設定
        SetBulletDirection(direction);
    }

    /// <summary>
    /// 弾が当たった敵を破壊
    /// </summary>
    /// <param name="col">衝突した相手のCollider2D</param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        // 衝突相手のタグが"Enemy"だったら
        if (col.CompareTag("Enemy"))
        {
            // このゲームオブジェクトを破壊
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 弾の向きを設定
    /// </summary>
    private void SetBulletDirection(Vector2 direction)
    {
        // 弾のSpriteRendererコンポーネントを取得
        if (TryGetComponent(out SpriteRenderer spriteRenderer))
        {
            // direction.x が正ならば右向き、負ならば左向き
            spriteRenderer.flipX = direction.x < 0f;
        }
    }
}
