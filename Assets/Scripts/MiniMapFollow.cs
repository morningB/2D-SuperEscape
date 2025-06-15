using UnityEngine;

// 미니맵 카메라를 플레이어에 따라 움직이게
public class MinimapFollow : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        Vector3 newPos = player.position;
        newPos.z = transform.position.z;
        transform.position = newPos;
    }
}
