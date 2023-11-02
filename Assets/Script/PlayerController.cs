using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private void Start()
    {
        // FPS��60�ɐ�������
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        // �L�[���͂��擾
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �ړ��x�N�g�����v�Z
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0.0f);
        moveDirection.Normalize();

        // �L�����N�^�[�̈ړ�
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}