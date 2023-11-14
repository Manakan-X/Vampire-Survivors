using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;     // �e�̃v���t�@�u
    public Transform firePoint;     // ���˃|�C���g
    public float fireRate = 2f;     // ���ˊԊu(�b)

    private float timer = 0f;   // �^�C�}�[
    private PlayerController playerController;      // PlayerController�ւ̎Q��

    private void Start()
    {
        // BulletGenerator���A�^�b�`���ꂽ�I�u�W�F�N�g����PlayerController���擾
        TryGetComponent(out playerController);
    }

    private void Update()
    {
        // �^�C�}�[���X�V
        timer += Time.deltaTime;

        // �w��̊Ԋu�Œe�𐶐����Ĕ���
        if (timer >= fireRate)
        {
            FireBullet();
            timer = 0f; // �^�C�}�[�����Z�b�g
        }
    }

    void FireBullet()
    {
        // �e�̐���
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        if (playerController != null )
        {
            // PlayerController��������Ă���������擾
            Vector2 direction = playerController.GetLookDirection();

            // Bullet��Shoot���\�b�h���Ăяo���Ēe�𔭎�
            bullet.GetComponent<Bullet>().Shoot(direction);
        }
    }
}
