using UnityEngine;

public class EnemyVertical : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = movingRight ? Vector2.up : Vector2.down;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        spriteRenderer.flipX = !movingRight;

        // patrol 범위 초과 시 방향 반전
        if (transform.position.y >= startPos.y + moveDistance)
            movingRight = false;
        else if (transform.position.y <= startPos.y - moveDistance)
            movingRight = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            movingRight = !movingRight;
        }
    }
}
