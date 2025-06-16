using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // Rigidbody2D가 필수 컴포넌트임을 명시
public class EnemyVertical : MonoBehaviour
{
    public float moveSpeed = 2f;    // 이동 속도
    private Rigidbody2D rb;         // 물리 기반 이동을 위한 Rigidbody2D
    private float moveDirection = 1f; // 이동 방향 (1: 위, -1: 아래)
    private SpriteRenderer spriteRenderer;
    public Transform player;
    public bool useFlipX = true;
    void Awake()
    {
        // 컴포넌트를 미리 캐싱하여 성능 향상
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // 물리 업데이트는 FixedUpdate에서 처리하는 것이 더 안정적입니다.
    void FixedUpdate()
    {
        if (useFlipX && player != null)
        {
            spriteRenderer.flipX = (player.position.x > transform.position.x);
        }
        // Y축으로만 속도를 가합니다.
        rb.linearVelocity = new Vector2(0, moveDirection * moveSpeed);
    }

    // 단단한 오브젝트와 충돌했을 때 호출되는 함수
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트의 태그가 "Wall"인지 확인
        if (collision.gameObject.CompareTag("Wall"))
        {
            // 방향을 반대로 바꿉니다.
            moveDirection *= -1;
            rb.linearVelocity = new Vector2(0, moveDirection * moveSpeed);
            // Debug.Log("벽과 충돌하여 방향을 전환합니다.");
        }
    }
}