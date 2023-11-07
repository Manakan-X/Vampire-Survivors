using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // �Ǐ]����Ώ�(�L�����N�^�[)

    public Vector3 offset; // �J�����ƃL�����N�^�[�̑��Έʒu�I�t�Z�b�g

    private void LateUpdate()
    {
        if (target == null)
        {
            // �J�����̈ʒu���L�����N�^�[�̈ʒu�ɍ��킹��
            transform.position = target.position + offset;
        }
    }
}
