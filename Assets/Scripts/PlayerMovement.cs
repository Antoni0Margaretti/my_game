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
        // Движение
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        // Управление анимацией
        animator.SetFloat("Speed", Mathf.Abs(moveX));
    }
}
