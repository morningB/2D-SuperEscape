using UnityEngine;
public class Fireball : MonoBehaviour
{
    public GameObject FireballExplosionPrefab;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 데미지 처리, 이펙트 등
            GameObject explosion = Instantiate(FireballExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 0.5f);  
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject); // 벽에 닿으면 사라짐
        }
    }
}

