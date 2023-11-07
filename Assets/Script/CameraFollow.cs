using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 追従する対象(キャラクター)

    public Vector3 offset; // カメラとキャラクターの相対位置オフセット

    private void LateUpdate()
    {
        if (target == null)
        {
            // カメラの位置をキャラクターの位置に合わせる
            transform.position = target.position + offset;
        }
    }
}
