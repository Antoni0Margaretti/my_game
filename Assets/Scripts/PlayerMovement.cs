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
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        // Управление анимацией движения
        animator.SetFloat("Speed", Mathf.Abs(moveX));

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
        scale.x *= -1; // Инвертируем ось X
        transform.localScale = scale; // Применяем изменение масштаба
    }
}

