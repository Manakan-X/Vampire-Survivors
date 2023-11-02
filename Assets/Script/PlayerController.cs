using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private void Start()
    {
        // FPSを60に制限する
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        // キー入力を取得
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 移動ベクトルを計算
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0.0f);
        moveDirection.Normalize();

        // キャラクターの移動
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}