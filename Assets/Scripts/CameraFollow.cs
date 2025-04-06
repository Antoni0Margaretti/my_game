using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока
    public Vector3 offset;   // Смещение камеры относительно игрока

    void Update()
    {
        if (player != null)
        {
            // Камера следует за игроком с учётом смещения
            transform.position = player.position + offset;
        }
    }
}