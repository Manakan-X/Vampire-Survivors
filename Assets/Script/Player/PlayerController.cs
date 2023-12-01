using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("�ړ����x")]
    public float moveSpeed;
    public int hp;
    public int expGage;         // EXP���擾�����瑝����

    private Rigidbody2D rb;       // �R���|�[�l���g�̎擾�p
    private Bullet bullet;      // �N���X�擾�p
    private float horizontal;   // x��(����)�����̓��͂̒l�̑���p
    private float vertical;     // y��(����)�����̓��͂̒l�̑���p

    private Animator anim;      // �R���|�[�l���g�̎擾�p
    private Vector2 lookDirection = new Vector2(0, -1.0f);      // �L�����̌����̏��̐ݒ�p

    private void Start()
    {
        // ���̃X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�A�ɃA�^�b�`����Ă���R���|�[�l���g�̒�����
        // <�w��>�����R���|�[�l���g�̏����擾���āA���ӂɗp�ӂ����ϐ��ɑ��
        TryGetComponent(out rb);

        TryGetComponent(out anim);
    }

    private void Update()
    {
        // InputManager��Horizontal�ɓo�^���Ă���L�[�����͂��ꂽ��A���������̓��͒l�Ƃ��đ��
        horizontal = Input.GetAxis("Horizontal");
        // InputManager��Vertical�ɓo�^���Ă���L�[�����͂��ꂽ��A���������̓��͒l�Ƃ��đ��
        vertical = Input.GetAxis("Vertical");

        if (anim)
        {
            // �L�����̌����Ă�������ƈړ��A�j���̓���
            SyncMoveAnimation();
        }
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

        if (dir != Vector3.zero)
        {
            // velocity(���x)�ɐV�����l�������āA�Q�[���I�u�W�F�N�g���ړ�������
            rb.velocity = dir * moveSpeed;
        }
        else
        {
            // ���͂��Ȃ��ꍇ�A���x���[���ɐݒ肵�Ē�~
            rb.velocity = Vector3.zero;
        }
    }

    /// <summary>
    /// �L�����̌����Ă�������ƈړ��A�j���̓���
    /// </summary>
     
    private void SyncMoveAnimation()
    {
        // �����ꂩ�̃L�[���͂����邩�m�F
        if (!Mathf.Approximately(horizontal, 0.0f) || !Mathf.Approximately(vertical, 0.0f))
        {
            // �����Ă���������X�V
            lookDirection.Set(horizontal, vertical);

            // ���K��
            lookDirection.Normalize();

            // �L�[���͂̒l��BlendTree�ł����Ă������ړ��A�j���p�̒l���m�F���A�ړ��A�j�����Đ�
            anim.SetFloat("Look X", lookDirection.x);
            anim.SetFloat("Look Y", lookDirection.y);

            // �L�[���͂̒l��BlendTree�Őݒ肵���ړ��A�j���p�̒l���m�F���A�ړ��A�j�����Đ�
            anim.SetFloat("Speed", lookDirection.sqrMagnitude);
        }
        else
        {
            // ��~�A�j���[�V����
            anim.SetFloat("Speed", 0);
        }
    }

    public Vector2 GetLookDirection()
    {
        return lookDirection;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // �G�ƂԂ�������
        if (col.gameObject.TryGetComponent(out EnemyController enemyController))       
        {
            // hp�����炷
            hp--;

            // hp��0�ɂȂ�����"Game Over"�����O�ɕ\��������
            if (hp <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }

    public void ExpGet()
    {
        // �v���C���[�̍U���œG��|������
        

        // �G��exp���v���C���[��expGage�ɉ��Z����
    }
}