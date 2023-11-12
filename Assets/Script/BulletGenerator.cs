using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab; // �e�̃v���t�@�u
    public Transform firePoint; // ���˃|�C���g
    public float fireRate = 2f; // ���ˊԊu(�b)

    private float timer = 0f; // �^�C�}�[
    private PlayerController playerController; // PlayerController�ւ̎Q��

    private void Start()
    {
        // PlayerController�R���|�[�l���g�̏���playerController�ϐ��ɃL���b�V������
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
        GameObject bulletObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();

        if (playerController != null )
        {
            // PlayerController��������Ă���������擾
            Vector2 playerLookDirection = playerController.GetLookDirection();

            // Bullet��Shoot���\�b�h���Ăяo���Ēe�𔭎�
            bullet.Shoot(playerLookDirection);
        }
    }
}
