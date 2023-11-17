using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �f�t�H���g
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;     // �e��

    [SerializeField] private float destroyTime;     // ���ł܂ł̎���

    /// <summary>
    /// �o���b�g����
    /// </summary>
    public void Shoot(Vector2 direction)
    {
        // ���̃Q�[���I�u�W�F�N�g��Rigidbody2D���A�^�b�`����Ă���΁A�ϐ�rb��Rigidbody2D��������
        if (TryGetComponent(out Rigidbody2D rb))
        {
            // direction(����)��bulletSpeed(�e��)�Ɋ�Â��āA�͂������Ĕ��˂���
            rb.AddForce(direction * bulletSpeed);
        }

        // ��莞�Ԍo�ߌ�A�e�����ł�����
        Destroy(gameObject, destroyTime);
    }

    /// <summary>
    /// �e�����������G��j��
    /// </summary>
    /// <param name="col">�Փ˂��������Collider2D</param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        // �Փˑ���̃^�O��"Enemy"��������
        if (col.CompareTag("Enemy"))
        {
            // ���̃Q�[���I�u�W�F�N�g��j��
            Destroy(gameObject);
        }
    }
}
