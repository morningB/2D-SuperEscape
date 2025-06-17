using UnityEngine;

public class ReStart : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public Camera camera;
    public Transform player;
    public Vector3 pos;
    public GameObject gameover;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown("r") && playerHealth.currentHealth <= 0)
        {
            GetComponent<HeroKnight>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            playerHealth.Heal(playerHealth.playerMaxHealth);
            camera.transform.position = new Vector3(pos.x, pos.y, pos.z - 1.0f);
            player.position = pos;
            gameover.SetActive(false);
        }
    }
}
