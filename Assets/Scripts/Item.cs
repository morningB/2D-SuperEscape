using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Text itemGetText;
    int count = 0;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Treasure"))
        {
            Debug.Log("아이템획득");
            count++;
            itemGetText.text = count + " / 6";
            Destroy(collision.gameObject);
        }
    }
}
