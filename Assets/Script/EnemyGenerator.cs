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
            // ˆê’èŠÔ‘Ò‹@‚µ‚Ä
            yield return new WaitForSeconds(interval);

            // “G‚ğì‚é
            GenerateEnemy();
        }
    }

    private void GenerateEnemy()
    {
        Instantiate(enemyPrefab);
    }
}
