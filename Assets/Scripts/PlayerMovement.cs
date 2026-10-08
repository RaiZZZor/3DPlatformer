using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Настройки движения")]
    public float moveSpeed = 7f;
    public float jumpForce = 5f;

    [Header("Проверка земли")]
    public LayerMask groundMask;
    public float groundCheckDistance = 0.3f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Проверка, стоит ли игрок на земле
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        // Движение по клавишам WASD / стрелкам
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        Vector3 newVelocity = moveDirection * moveSpeed;
        newVelocity.y = rb.linearVelocity.y; // Сохраняем физику падения/прыжка

        rb.linearVelocity = newVelocity;

        // Прыжок на Пробел
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}