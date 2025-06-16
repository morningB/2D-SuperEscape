using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;             // 이동 속도
    public float moveDistance = 3f;          // 이동 거리
    private Vector3 startPos;
    private bool movingRight = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        GetComponent<Animator>().SetBool("bMove", true);

        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        transform.Translate(direction* moveSpeed * Time.deltaTime);

        spriteRenderer.flipX = !movingRight;
        
        // patrol 범위 초과 시 방향 반전
        if (transform.position.x >= startPos.x + moveDistance)
            movingRight = false;
        else if (transform.position.x <= startPos.x - moveDistance)
            movingRight = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            movingRight = !movingRight;
            Debug.Log("벽 충돌");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            movingRight = !movingRight;
            Debug.Log("벽 충돌");
        }
    }
}
