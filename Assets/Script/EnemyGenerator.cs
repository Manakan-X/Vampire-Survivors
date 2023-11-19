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
            // ��莞�ԑҋ@����
            yield return new WaitForSeconds(interval);

            // �G�����
            GenerateEnemy();
        }
    }

    private void GenerateEnemy()
    {
        Instantiate(enemyPrefab);
    }
}
