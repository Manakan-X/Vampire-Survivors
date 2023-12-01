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
            // 弾の向きを調整(弾先がプレイヤーの進行方向を向くように)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // direction(方向)とbulletSpeed(弾速)に基づいて、力を加えて発射する
            rb.AddForce(direction * bulletSpeed);
        }

        // 一定時間経過後、弾を消滅させる
        Destroy(gameObject, destroyTime);
    }
}
