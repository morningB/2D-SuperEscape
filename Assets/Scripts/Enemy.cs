using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public int enemyHealth = 3;
    public AudioClip audioClip;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, Vector2 knockback)
    {
        if (enemyHealth <= 0)
        {
            //GetComponent<CapsuleCollider2D>().enabled = false;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            GetComponent<Animator>().enabled = false;
            if(GetComponent<EnemyPatrol>() != null)
                GetComponent<EnemyPatrol>().enabled = false;
            if(GetComponent<EnemyShooter>() != null)
                GetComponent<EnemyShooter>().enabled = false;
            if(GetComponent<EnemyVertical>() != null)
                GetComponent<EnemyVertical>().enabled = false;
            
            Destroy(gameObject, 1f);
        }
        rb.linearVelocity = Vector2.zero;  // 기존 속도 제거
        rb.AddForce(knockback, ForceMode2D.Impulse);
        // 체력 감소, 피격 애니메이션, 무적 처리 등 추가 가능
        enemyHealth -= damage;
        GetComponent<AudioSource>().PlayOneShot(audioClip);
        Debug.Log("적이 피해 입음" + damage);
    }
}

