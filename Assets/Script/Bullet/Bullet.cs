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

    public int atackPower;      // �e�̍U����

    /// <summary>
    /// �o���b�g����
    /// </summary>
    public void Shoot(Vector2 direction)
    {
        // ���̃Q�[���I�u�W�F�N�g��Rigidbody2D���A�^�b�`����Ă���΁A�ϐ�rb��Rigidbody2D��������
        if (TryGetComponent(out Rigidbody2D rb))
        {
            // �e�̌����𒲐�(�e�悪�v���C���[�̐i�s�����������悤��)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // direction(����)��bulletSpeed(�e��)�Ɋ�Â��āA�͂������Ĕ��˂���
            rb.AddForce(direction * bulletSpeed);
        }

        // ��莞�Ԍo�ߌ�A�e�����ł�����
        Destroy(gameObject, destroyTime);
    }
}
