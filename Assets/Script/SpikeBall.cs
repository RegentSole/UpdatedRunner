using UnityEngine;

public class RandomPush : MonoBehaviour
{
    public float pushInterval = 2f; // Интервал между толчками
    public float pushForce = 100f;  // Сила толчка

    private Rigidbody2D rb;
    private float nextPushTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextPushTime = Time.time + pushInterval;
    }

    void Update()
    {
        if (Time.time >= nextPushTime)
        {
            Push();
            nextPushTime += pushInterval;
        }
    }

    void Push()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.AddForce(randomDirection * pushForce);
    }
}