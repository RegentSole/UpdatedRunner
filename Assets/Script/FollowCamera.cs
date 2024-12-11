using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    // Ссылка на объект, за которым следует камера
    public Transform target;

    // Смещение камеры относительно цели
    public Vector3 offset;

    // Скорость сглаживания камеры
    public float smoothSpeed = 5f;

    void FixedUpdate()
    {
        // Вычисляем желаемую позицию камеры
        Vector3 desiredPosition = target.position + offset;

        // Интерполируем текущую позицию камеры к желаемой
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);

        // Устанавливаем новую позицию камеры
        transform.position = smoothedPosition;
    }
}