using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость передвижения персонажа
    public float jumpForce = 7f; // Сила прыжка

    private Rigidbody2D rb;       // Компонент Rigidbody2D для управления физикой
    private bool isGrounded;      // Флаг, определяющий находится ли персонаж на земле
    private SpriteRenderer spriteRenderer; // Компонент для работы со спрайтом

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Добавляем ссылку на SpriteRenderer
    }

    void Update()
    {
        Move();
        Jump();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Проверяем, что мы находимся на земле (находимся на коллайдере)
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Если покидаем землю, то больше не можем прыгнуть
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Move()
    {
        // Получаем значение оси X для движения по горизонтали
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        // Меняем масштаб персонажа, если идём назад
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Переворачиваем персонажа
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // Возвращаемся к исходному виду
        }

        // Двигаемся вправо или влево
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    void Jump()
    {
        // Прыгаем, если нажата клавиша "Пробел" и мы стоим на земле
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false; // После прыжка мы уже не на земле
        }
    }
}