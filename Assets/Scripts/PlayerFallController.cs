using UnityEngine;
using System.Collections;

public class PlayerFallController : MonoBehaviour
{
   public Transform targetPosition;         // 이동할 목표 위치
    public float moveDuration = 1.5f;        // 이동 시간
    public float rotationSpeed = 720f;       // 초당 회전 각도

    private bool isControlEnabled = true;
    private bool isMovingToTarget = false;

    private Animator animator;
    public CameraController cameraController; // 드래그해서 연결
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isControlEnabled)
            return;

        // 일반 이동 등 처리
    }

    public void LaunchToPosition()
    {
        if (isMovingToTarget) return;

        isMovingToTarget = true;
        isControlEnabled = false;

        // 낙하 애니메이션 실행
        if (animator != null)
            animator.Play("Fall");

        StartCoroutine(RotateAndMoveToTarget());
    }

    private IEnumerator RotateAndMoveToTarget()
    {
        Vector3 start = transform.position;
        Vector3 end = targetPosition.position;
        float time = 0f;

        // 카메라도 같이 이동
        cameraController.MoveTo(end);

        while (time < moveDuration)
        {
            float t = time / moveDuration;
            transform.position = Vector3.Lerp(start, end, t);

            // Z축 회전
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

            time += Time.deltaTime;
            yield return null;
        }

        // 최종 위치 보정
        transform.position = end;
        transform.rotation = Quaternion.identity;

        // 상태 복구
        isMovingToTarget = false;
        isControlEnabled = true;

        if (animator != null)
            animator.Play("Idle"); // 착지 후 대기 상태 등
    }
}
