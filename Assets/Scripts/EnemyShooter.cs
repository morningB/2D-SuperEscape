using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public Transform firePoint2;
    public float fireForce = 5f;
    public float fireInterval = 2f;
    public bool useFlipX = true; // ✅ 선택적으로 반전

    private SpriteRenderer spriteRenderer;
    private Transform player;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        InvokeRepeating(nameof(Fire), 0f, fireInterval);
    }

    void Update()
    {
        if (useFlipX && player != null)
        {
            // 플레이어 위치에 따라 반전
            spriteRenderer.flipX = (player.position.x > transform.position.x);
        }
    }

    void Fire()
    {
        if (fireballPrefab == null || firePoint == null) return;
        GameObject fireball;
        if (spriteRenderer.flipX)
        {
            fireball = Instantiate(fireballPrefab, firePoint2.position, Quaternion.identity);
            
        }
        else
             fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

        Vector2 direction = spriteRenderer.flipX ? Vector2.right : Vector2.left;

        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * fireForce;
        }
    }
}
