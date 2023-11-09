using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("移動速度")]
    public float moveSpeed;

    private Rigidbody2D rb;       // コンポーネントの取得用

    private float horizontal;   // x軸(水平)方向の入力の値の代入用
    private float vertical;     // y軸(垂直)方向の入力の値の代入用

    private Animator anim;
    private Vector2 lookDirection = new Vector2(0, -1.0f);      // キャラの向きの情報の設定用

    private void Start()
    {
        // このスクリプトがアタッチされているゲームオブジェクト、にアタッチされているコンポーネントの中から
        // <指定>したコンポーネントの情報を取得して、左辺に用意した変数に代入
        rb = GetComponent<Rigidbody2D>();

        TryGeyComponent(out anim);
    }

    private void Update()
    {
        // InputManagerのHorizontalに登録してあるキーが入力されたら、水平方向の入力値として代入
        horizontal = Input.GetAxis("Horizontal");
        // InputManagerのVerticalに登録してあるキーが入力されたら、垂直方向の入力値として代入
        vertical = Input.GetAxis("Vertical");

        if (anim)
        {
            // キャラの向いている方向と移動アニメの同期
            SyncMoveAnimation();
        }
    }

    private void FixedUpdate()
    {
        // 移動
        Move();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // 斜めの移動距離を正規化処理を行い均一化する
        Vector3 dir = new Vector3(horizontal, vertical, 0).normalized;

        if (dir != Vector3.zero)
        {
            // velocity(速度)に新しい値を代入して、ゲームオブジェクトを移動させる
            rb.velocity = dir * moveSpeed;
        }
        else
        {
            // 入力がない場合、速度をゼロに設定して停止
            rb.velocity = Vector3.zero;
        }
    }

    /// <summary>
    /// キャラの向いている方向と移動アニメの同期
    /// </summary>
     
    private void SyncMoveAnimation()
    {
        // いずれかのキー入力があるか確認
        if (!Mathf.Approximately(horizontal, 0.0f) || !Mathf.Approximately(vertical, 0.0f))
        {
            // 向いている方向を更新
            lookDirection.Set(horizontal, vertical);
        }
    }
}