using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] EnemyController enemyPrefab;
    [SerializeField] float interval;
    Transform player; // �v���C���[��Transform

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;      // �v���C���[��Transform���擾
        StartCoroutine(GenerateEnemyInterval());
    }

    private IEnumerator GenerateEnemyInterval()
    {
        while (true)
        {
            // ��莞�ԑҋ@����
            yield return new WaitForSeconds(interval);

            // �G�����
            float randomAngle = Random.Range(0f, 360f);
            GenerateEnemy(randomAngle);
        }
    }

    private void GenerateEnemy(float angle)
    {
        // �v���C���[�̕����ɐi�ރx�N�g�����v�Z
        Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.up;

        // ��ʊO�̓K�؂Ȉʒu�ɓG�𐶐�
        float spawnDistance = 15f;      // ��ʊO����̋���(�K�v�ɉ�����)
        Vector3 spawnPosition = player.position + direction * spawnDistance;

        // �G�𐶐����ăv���C���[�̕����ɐi�܂���
        EnemyController enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
