using UnityEngine;

public class LaserGateTrigger : MonoBehaviour
{
    // LaserGateTrigger.cs
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerFallController>().HitByLaser();
        }
    }

}
