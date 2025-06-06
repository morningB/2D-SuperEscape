using UnityEngine;

public class ButtonDoorController : MonoBehaviour
{
    public Transform door;                         // 문 Transform
    public Vector3 doorClosedPosition;             // 문 기본 위치
    public Vector3 doorOpenedPosition;             // 열릴 위치

    public SpriteRenderer buttonSpriteRenderer;
    public Sprite buttonUpSprite;
    public Sprite buttonDownSprite;

    private int objectsOnButton = 0;
    private bool isPressed => objectsOnButton > 0;

    public float doorSpeed = 3f;

    void Start()
    {
        doorClosedPosition = door.position;
        doorOpenedPosition = doorClosedPosition + new Vector3(0f, 2f, 0f); // 예: 위로 2단

    }
    void Update()
    {
        // 문 위치 이동
        Vector3 target = isPressed ? doorOpenedPosition : doorClosedPosition;
        door.position = Vector3.Lerp(door.position, target, Time.deltaTime * doorSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objectsOnButton++;
            buttonSpriteRenderer.sprite = buttonDownSprite;
        }
    }

}
