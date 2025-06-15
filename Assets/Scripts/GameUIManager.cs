using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public GameObject victory;
    void Start()
    {
        victory.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Crown"))
        {
            victory.SetActive(true);
        }

    }
    
}
