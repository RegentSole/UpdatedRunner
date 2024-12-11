using UnityEngine;
using System.Collections;

public class ObjectPusher : MonoBehaviour
{
    // Переменная для хранения заслона
    public GameObject barrier;
    
    // Максимальная высота, до которой должен подняться заслон
    public float maxHeight = 5f;
    
    // Переменная для хранения скорости подъема заслона
    public float barrierMoveSpeed = 10f;

    private bool isBarrierRaised = false; // Флаг, определяющий поднятый ли уже заслон

    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, что столкновение произошло с объектом с нужным тегом
        if (other.CompareTag("PushObject") && !isBarrierRaised)
        {
            StartCoroutine(RaiseBarrier());
        }
    }

    IEnumerator RaiseBarrier()
    {
        isBarrierRaised = true;
        
        // Сохранение начальной позиции заслона
        var startPosition = barrier.transform.position;
        
        // Подъем заслона до максимальной высоты
        while (barrier.transform.position.y < startPosition.y + maxHeight)
        {
            barrier.transform.Translate(0, barrierMoveSpeed * Time.deltaTime, 0);
            yield return null;
        }
        
        // Установка финальной позиции заслона
        barrier.transform.position = new Vector3(startPosition.x, startPosition.y + maxHeight, startPosition.z);
    }
}