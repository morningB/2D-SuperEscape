using UnityEngine;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;

public class PlayerFallController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float knockUpForce = 5f;
    public float knockForwardForce = 2f;
    public bool isHit = false;
    public GameObject ui;
    public GameObject titleImage;
    public Transform fallEntryPoint; // 다리 중앙 위치
    public Transform cameraTransform; // Main Camera 참조

    public Transform moveMapTargetPoint; // MoveMap 충돌 시 이동할 위치
    public Transform secCamera;
    public Transform moveThirdMapTargetPoint; // ThirdMap 충돌 시 이동할 위치
    public Transform thirdCamera;
    public Transform moveFourthMapTargetPoint; // FourdMap 충돌 시 이동할 위치
    public Transform fourCamera;
    public Transform moveFivehMapTargetPoint; // FivedMap 충돌 시 이동할 위치
    public Transform fiveCamera;
    public Transform moveSixMapTargetPoint; // SixMap 충돌 시 이동할 위치
    public Transform sixCamera;
    public Transform moveSevenMapTargetPoint; // SevenMap 충돌 시 이동할 위치
    public Transform sevenCamera;
    public Transform moveLastMapTargetPoint; // LastdMap 충돌 시 이동할 위치
    public Transform lastCamera;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ui.SetActive(false);
        titleImage.SetActive(true);
        // 카메라와의 현재 거리 저장
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

    }

    public void HitByLaser()
    {
        if (isHit) return;
        isHit = true;
        titleImage.SetActive(false);
        animator.SetTrigger("Hurt");

        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;

        StartCoroutine(MoveToFallPoint());
    }

    IEnumerator MoveToFallPoint()
    {
        Vector3 start = transform.position;
        Vector3 target = fallEntryPoint.position;

        Vector3 cameraStart = cameraTransform.position;
        Vector3 cameraTarget = new Vector3(target.x, target.y, cameraTransform.position.z);

        float duration = 2.0f;
        float elapsed = 0f;

        float totalRotation = 360f; // 또는 더 크게
        float rotateSpeed = totalRotation / duration; // 초당 회전량

        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            // 이동
            transform.position = Vector3.Lerp(start, target, t);
            cameraTransform.position = Vector3.Lerp(cameraStart, cameraTarget, t);

            // 회전
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // 위치 보정
        transform.position = target;
        cameraTransform.position = cameraTarget;
        transform.rotation = Quaternion.identity;

        // 낙하 시작
        rb.gravityScale = 1f;
        rb.AddForce(Vector2.down * knockUpForce, ForceMode2D.Impulse);
    }


    IEnumerator MoveToNewMap(Vector3 targetPosition, Transform mapMovecameraTransform)
    {
        // 1. 즉시 플레이어 위치 이동 (Z값 유지)
        targetPosition.z = transform.position.z;
        transform.position = targetPosition;

        // 2. 즉시 카메라 위치 이동
        Vector3 cameraTarget = new Vector3(mapMovecameraTransform.position.x, mapMovecameraTransform.position.y, cameraTransform.position.z);
        cameraTransform.position = cameraTarget;

        yield break;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MoveMap"))
        {
            ui.SetActive(true);
            StartCoroutine(MoveToNewMap(moveMapTargetPoint.position, secCamera));
        }

        if (other.CompareTag("ThirdMap"))
        {
            StartCoroutine(MoveToNewMap(moveThirdMapTargetPoint.position, thirdCamera));
        }

        if (other.CompareTag("FourthMap"))
        {
            StartCoroutine(MoveToNewMap(moveFourthMapTargetPoint.position, fourCamera));
        }

        if (other.CompareTag("FivethMap"))
        {
            StartCoroutine(MoveToNewMap(moveFivehMapTargetPoint.position, fiveCamera));
        }

        if (other.CompareTag("SixMap"))
        {
            StartCoroutine(MoveToNewMap(moveSixMapTargetPoint.position, sixCamera));
        }

        if (other.CompareTag("SevenMap"))
        {
            StartCoroutine(MoveToNewMap(moveSevenMapTargetPoint.position, sevenCamera));
        }

        if (other.CompareTag("LastMap"))
        {
            StartCoroutine(MoveToNewMap(moveLastMapTargetPoint.position, lastCamera));
        }
    }
    
}
