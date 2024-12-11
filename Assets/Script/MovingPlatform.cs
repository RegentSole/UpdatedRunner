using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveDistance = 2f;       // Расстояние, на которое платформа поднимается
    [SerializeField] private float moveDuration = 1f;       // Время подъема платформы
    [SerializeField] private float waitTime = 1f;           // Время ожидания перед возвращением платформы обратно
    [SerializeField] private LayerMask playerLayer;         // Слой, на котором находится игрок

    private Vector3 startPosition;                          // Исходная позиция платформы
    private Coroutine movingCoroutine;                      // Корутина для анимации движения платформы

    void Start()
    {
        startPosition = transform.position;                 // Сохраняем начальную позицию платформы
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, что в зону вошел объект с нужным слоем (игрок)
        if ((playerLayer.value & 1 << other.gameObject.layer) != 0)
        {
            MovePlatformUp();                                // Начинаем подъем платформы
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Проверяем, что из зоны вышел объект с нужным слоем (игрок)
        if ((playerLayer.value & 1 << other.gameObject.layer) != 0)
        {
            MovePlatformDown();                              // Возвращаем платформу обратно
        }
    }

    private void MovePlatformUp()
    {
        // Останавливаем предыдущую корутину, если она запущена
        if (movingCoroutine != null)
        {
            StopCoroutine(movingCoroutine);
        }

        // Запускаем новую корутину для подъема платформы
        movingCoroutine = StartCoroutine(MovePlatform(startPosition, startPosition + Vector3.up * moveDistance, moveDuration));
    }

    private void MovePlatformDown()
    {
        // Останавливаем предыдущую корутину, если она запущена
        if (movingCoroutine != null)
        {
            StopCoroutine(movingCoroutine);
        }

        // Ждем некоторое время перед возвратом платформы
        StartCoroutine(WaitAndMoveBack());
    }

    private IEnumerator WaitAndMoveBack()
    {
        yield return new WaitForSeconds(waitTime);           // Ждем указанное время

        // Запускаем корутину для возвращения платформы обратно
        movingCoroutine = StartCoroutine(MovePlatform(transform.position, startPosition, moveDuration));
    }

    private IEnumerator MovePlatform(Vector3 start, Vector3 end, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = end;                            // Устанавливаем конечную позицию платформы
    }
}