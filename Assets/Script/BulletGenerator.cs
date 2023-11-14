using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;     // 弾のプレファブ
    public Transform firePoint;     // 発射ポイント
    public float fireRate = 2f;     // 発射間隔(秒)

    private float timer = 0f;   // タイマー
    private PlayerController playerController;      // PlayerControllerへの参照

    private void Start()
    {
        // BulletGeneratorがアタッチされたオブジェクトからPlayerControllerを取得
        TryGetComponent(out playerController);
    }

    private void Update()
    {
        // タイマーを更新
        timer += Time.deltaTime;

        // 指定の間隔で弾を生成して発射
        if (timer >= fireRate)
        {
            FireBullet();
            timer = 0f; // タイマーをリセット
        }
    }

    void FireBullet()
    {
        // 弾の生成
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        if (playerController != null )
        {
            // PlayerControllerから向いている方向を取得
            Vector2 direction = playerController.GetLookDirection();

            // BulletのShootメソッドを呼び出して弾を発射
            bullet.GetComponent<Bullet>().Shoot(direction);
        }
    }
}
