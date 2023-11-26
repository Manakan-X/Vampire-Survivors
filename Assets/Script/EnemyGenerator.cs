using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] EnemyController enemyPrefab;
    [SerializeField] float interval;
    Transform player; // プレイヤーのTransform

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;      // プレイヤーのTransformを取得
        StartCoroutine(GenerateEnemyInterval());
    }

    private IEnumerator GenerateEnemyInterval()
    {
        while (true)
        {
            // 一定時間待機して
            yield return new WaitForSeconds(interval);

            // 敵を作る
            float randomAngle = Random.Range(0f, 360f);
            GenerateEnemy(randomAngle);
        }
    }

    private void GenerateEnemy(float angle)
    {
        // プレイヤーの方向に進むベクトルを計算
        Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.up;

        // 画面外の適切な位置に敵を生成
        float spawnDistance = 15f;      // 画面外からの距離(必要に応じて)
        Vector3 spawnPosition = player.position + direction * spawnDistance;

        // 敵を生成してプレイヤーの方向に進ませる
        EnemyController enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
