using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float moveDuration = 1.5f;

    private bool isMoving = false;
    private Vector3 startPos;
    private Vector3 endPos;
    private float timer;

    public void MoveTo(Vector3 destination)
    {
        startPos = transform.position;
        endPos = new Vector3(destination.x, destination.y, transform.position.z);
        timer = 0f;
        isMoving = true;
    }

    void LateUpdate()
    {
        if (isMoving)
        {
            timer += Time.deltaTime;
            float t = timer / moveDuration;
            transform.position = Vector3.Lerp(startPos, endPos, t);

            if (t >= 1f)
                isMoving = false;
        }
    }
}

