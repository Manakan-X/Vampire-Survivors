using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] PlayerStatus playerStatus;

    public int enemyExp;

    private void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            // ’e‚ÌUŒ‚—Í‚Ì•ª‚¾‚¯hp‚ğŒ¸‚ç‚·
            hp -= bullet.atackPower;

            // hp‚ª0ˆÈ‰º‚É‚È‚Á‚Ä‚¢‚é‚©Šm”F‚·‚é
            if (hp <= 0)
            {
                // hp‚ª0ˆÈ‰º‚¾‚Á‚½‚ç“G‚ğ”j‰ó‚·‚é
                Destroy(gameObject);
                // PlayerStatus‚Ìexp•Ï”‚ÉenemyExp‚ğ‰ÁZ
                playerStatus.exp += enemyExp;
            }
            Destroy(bullet.gameObject);
        }
    }
}
