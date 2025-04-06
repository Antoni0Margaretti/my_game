using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Animator animator;

    private bool facingRight = true; // Переменная для отслеживания направления персонажа

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Получаем ввод игрока
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        // Управление анимацией движения
        if (Mathf.Abs(moveX) < 0.01f)
        {
            animator.SetFloat("Speed", 0); // Сброс анимации при остановке
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Abs(moveX));
        }

        // Поворот персонажа в зависимости от направления
        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveX < 0 && facingRight)
        {
            Flip();
        }
    }

    // Метод для поворота персонажа
    void Flip()
    {
        facingRight = !facingRight; // Меняем состояние
        Vector3 scale = transform.localScale;
        scale.x = facingRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x); // Устанавливаем направление
        transform.localScale = scale;
    }
}