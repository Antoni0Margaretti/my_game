using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        // Управление анимацией
        animator.SetFloat("Speed", Mathf.Abs(moveX)); // Обновляем параметр скорости

        // Остановка движения (плавное торможение)
        if (Mathf.Abs(moveX) < 0.01f)
        {
            animator.SetFloat("Speed", 0); // Устанавливаем точный ноль для остановки
        }
    }
}