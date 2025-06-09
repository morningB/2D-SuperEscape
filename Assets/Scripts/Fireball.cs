using UnityEngine;
public class Fireball : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 데미지 처리, 이펙트 등
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject); // 벽에 닿으면 사라짐
        }
    }
}

