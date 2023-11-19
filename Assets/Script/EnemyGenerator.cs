using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] EnemyController enemyPrefab;
    [SerializeField] float interval;

    private void Start()
    {
        StartCoroutine(GenerateEnemyInterval());
    }

    private IEnumerator GenerateEnemyInterval()
    {
        while (true)
        {
            // 一定時間待機して
            yield return new WaitForSeconds(interval);

            // 敵を作る
            GenerateEnemy();
        }
    }

    private void GenerateEnemy()
    {
        Instantiate(enemyPrefab);
    }
}
