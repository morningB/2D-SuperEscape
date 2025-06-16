using System.Collections;
using Unity.Profiling;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerMaxHealth = 3;
    public int currentHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private Animator animator;
    private bool isInvulnerable = false;
    public float invulnerableTime = 1f;
    public GameObject fireballExplosionPrefab;
    public GameObject gameover;
    public AudioClip damagedAudio;
    public AudioClip deathAudio;
    void Start()
    {
        currentHealth = playerMaxHealth;
        animator = GetComponent<Animator>();
        gameover.SetActive(false);
        UpdateHeartsUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        // 플레이어가 Fireball이나 Enemy 본체에 직접 맞았을 때만 처리
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
            GetComponent<AudioSource>().PlayOneShot(damagedAudio);
        }

        if (other.CompareTag("Fireball"))
        {

            TakeDamage(1);
            // 자식 오브젝트에 충돌했을 경우도 삭제하도록 보장
            GetComponent<AudioSource>().PlayOneShot(damagedAudio);
            Destroy(other.transform.root.gameObject);
        }
        if (other.CompareTag("magma"))
        {
            TakeDamage(playerMaxHealth);
        }

    }


    void TakeDamage(int damage)
    {
        if (currentHealth <= 0 || isInvulnerable)
            return;

        HeroKnight hero = GetComponent<HeroKnight>();

        if (hero != null && hero.isBlocking)
        {
            // 방어 중에는 데미지 무시
            Debug.Log("방어 성공! 데미지를 받지 않음.");
            return;
        }

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, playerMaxHealth);

        animator.SetTrigger("Hurt");

        UpdateHeartsUI();

        if (currentHealth <= 0)
        {
            Debug.Log("플레이어 사망!");
            GetComponent<AudioSource>().PlayOneShot(deathAudio);
            GetComponent<HeroKnight>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;

            animator.SetTrigger("Death");
            gameover.SetActive(true);
        }
        else
        {
            StartCoroutine(InvulnerabilityCoroutine());
        }
    }

    IEnumerator InvulnerabilityCoroutine()
    {
        isInvulnerable = true;

        // 1초 동안 무적 상태 유지
        yield return new WaitForSeconds(invulnerableTime);

        isInvulnerable = false;
    }
    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;

                // 알파값을 완전하게 설정
                Color color = hearts[i].color;
                color.a = 1f;
                hearts[i].color = color;
            }
            else
            {
                hearts[i].sprite = emptyHeart;

                // 알파값을 희미하게 설정
                Color color = hearts[i].color;
                color.a = 0.2f;  // 희미하게
                hearts[i].color = color;
            }
        }
    }
    public void Heal(int amount)
    {
        if (currentHealth >= playerMaxHealth)
            return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, playerMaxHealth);
        UpdateHeartsUI();
    }

}
