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
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            spriteRenderer.flipX = false;
            if (transform.position.x >= startPos.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            spriteRenderer.flipX = true;
            if (transform.position.x <= startPos.x - moveDistance)
                movingRight = true;
        }
    }
}
