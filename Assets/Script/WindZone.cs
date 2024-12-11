using UnityEngine;

public class WindZone : MonoBehaviour
{
    [SerializeField] private float windForce = 5f;
    [SerializeField] private float liftMultiplier = 1.5f; // Коэффициент подъёма

    private Rigidbody2D playerRb;
    private bool isInWindZone = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRb = collision.GetComponent<Rigidbody2D>();
            isInWindZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInWindZone = false;
        }
    }

    private void FixedUpdate()
    {
        if (isInWindZone && playerRb != null)
        {
            ApplyWindForce();
        }
    }

    private void ApplyWindForce()
    {
        // Подъёмный ветер
        Vector2 windDirection = Vector2.up * windForce * liftMultiplier;
        playerRb.AddForce(windDirection, ForceMode2D.Force);
    }
}