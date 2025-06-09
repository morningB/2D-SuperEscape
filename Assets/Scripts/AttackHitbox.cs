using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public float knockbackForce = 5f;
    public int facingDirection = 1; // -1 or 1

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                Vector2 direction = new Vector2(facingDirection, 0f);
                enemy.TakeDamage(1, direction * knockbackForce);
            }
        }
    }
}
