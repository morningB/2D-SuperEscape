using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Text itemGetText;
    int count = 0;
    public AudioClip getItemAudio;
    public PlayerHealth health;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Treasure"))
        {
            Debug.Log("아이템획득");
            count++;
            if(health.currentHealth < health.playerMaxHealth)
                health.currentHealth++;
            GetComponent<AudioSource>().PlayOneShot(getItemAudio);
            itemGetText.text = count + " / 6";
            Destroy(collision.gameObject);
        }
    }
}
