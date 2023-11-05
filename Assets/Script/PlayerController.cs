using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�ړ����x")]
    public float moveSpeed;

    private Rigidbody2D rb;       // �R���|�[�l���g�̎擾�p

    private float horizontal;   // x��(����)�����̓��͂̒l�̑���p
    private float vertical;     // y��(����)�����̓��͂̒l�̑���p

    private void Start()
    {
        // ���̃X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�A�ɃA�^�b�`����Ă���R���|�[�l���g�̒�����
        // <�w��>�����R���|�[�l���g�̏����擾���āA���ӂɗp�ӂ����ϐ��ɑ��
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // InputManager��Horizontal�ɓo�^���Ă���L�[�����͂��ꂽ��A���������̓��͒l�Ƃ��đ��
        horizontal = Input.GetAxis("Horizontal");
        // InputManager��Vertical�ɓo�^���Ă���L�[�����͂��ꂽ��A���������̓��͒l�Ƃ��đ��
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // �ړ�
        Move();
    }

    /// <summary>
    /// �ړ�
    /// </summary>
    private void Move()
    {
        // �΂߂̈ړ������𐳋K���������s���ψꉻ����
        Vector3 dir = new Vector3(horizontal, vertical, 0).normalized;
        // velocity(���x)�ɐV�����l�������āA�Q�[���I�u�W�F�N�g���ړ�������
        rb.velocity = dir * moveSpeed;
    }
}