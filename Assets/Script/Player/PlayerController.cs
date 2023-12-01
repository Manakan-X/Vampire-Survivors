using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("移動速度")]
    public float moveSpeed;
    public int hp;
    public int expGage;         // EXPを取得したら増える

    private Rigidbody2D rb;       // コンポーネントの取得用
    private Bullet bullet;      // クラス取得用
    private float horizontal;   // x軸(水平)方向の入力の値の代入用
    private float vertical;     // y軸(垂直)方向の入力の値の代入用

    private Animator anim;      // コンポーネントの取得用
    private Vector2 lookDirection = new Vector2(0, -1.0f);      // キャラの向きの情報の設定用

    private void Start()
    {
        // このスクリプトがアタッチされているゲームオブジェクト、にアタッチされているコンポーネントの中から
        // <指定>したコンポーネントの情報を取得して、左辺に用意した変数に代入
        TryGetComponent(out rb);

        TryGetComponent(out anim);
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

            // 正規化
            lookDirection.Normalize();

            // キー入力の値とBlendTreeでせっていした移動アニメ用の値を確認し、移動アニメを再生
            anim.SetFloat("Look X", lookDirection.x);
            anim.SetFloat("Look Y", lookDirection.y);

            // キー入力の値とBlendTreeで設定した移動アニメ用の値を確認し、移動アニメを再生
            anim.SetFloat("Speed", lookDirection.sqrMagnitude);
        }
        else
        {
            // 停止アニメーション
            anim.SetFloat("Speed", 0);
        }
    }

    public Vector2 GetLookDirection()
    {
        return lookDirection;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // 敵とぶつかったら
        if (col.gameObject.TryGetComponent(out EnemyController enemyController))       
        {
            // hpを減らす
            hp--;

            // hpが0になったら"Game Over"をログに表示させる
            if (hp <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }

    public void ExpGet()
    {
        // プレイヤーの攻撃で敵を倒したら
        

        // 敵のexpをプレイヤーのexpGageに加算する
    }
}