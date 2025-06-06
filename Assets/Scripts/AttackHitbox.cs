using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public float knockbackForce = 5f;
    public int facingDirection = 1; // -1 or 1

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                Vector2 forceDir = new Vector2(facingDirection * knockbackForce, 2f); // 위로 살짝 튕기게
                enemyRb.linearVelocity = Vector2.zero;
                enemyRb.AddForce(forceDir, ForceMode2D.Impulse);
            }
        }
    }
}
