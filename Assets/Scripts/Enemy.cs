using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, Vector2 knockback)
    {
        rb.linearVelocity = Vector2.zero;  // 기존 속도 제거
        rb.AddForce(knockback, ForceMode2D.Impulse);
        // 체력 감소, 피격 애니메이션, 무적 처리 등 추가 가능
    }
}

