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
        // �v���C���[�I�u�W�F�N�g����PlayerController�R���|�[�l���g���擾
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)       // playerObject��null����Ȃ����
        {
            // playerObject�ɃA�^�b�`����Ă���PlayerController���擾���āA�ϐ�playerController�ɑ������
            playerController = playerObject.GetComponent<PlayerController>();

            // playerController��null�������ꍇ
            if (playerController == null)
            {
                Debug.LogError("PlayerController�R���|�[�l���g��������܂���ł����B");
            }
        }
        else
        {
            Debug.LogError("�v���C���[�I�u�W�F�N�g��������܂���ł����B");
        }
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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        if (playerController != null)
        {
            // PlayerController��������Ă���������擾
            Vector2 direction = playerController.GetLookDirection();
            
            // Bullet��Shoot���\�b�h���Ăяo���Ēe�𔭎�
            bullet.GetComponent<Bullet>().Shoot(direction);
        }
    }
}
