using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float amplitude = 0.5f;  // 위아래 이동 폭
    public float frequency = 1f;    // 위아래 속도

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition; // UI는 localPosition을 사용
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
    }
}
