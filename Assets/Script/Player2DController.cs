using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 150;
    public bool isGrounded = true;

    private float moveValue;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Keyboard.current != null) // รับ Input จาก Keyboard กด D = +1 (ขวา), A = -1 (ซ้าย)
        {
            moveValue = (Keyboard.current.dKey.isPressed ? 1f : 0) - (Keyboard.current.aKey.isPressed ? 1f : 0);
        }

        _rb.linearVelocity = new Vector2(moveValue * speed, _rb.linearVelocity.y); // ขยับโดยการเพิ่มความเร็วตามติดทาง Input * Speed
        
        // Jump Logic
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded) // กด Spacebar // พร้อมเช็คว่าอยู่ที่พื้นมั้ย
        {
            _rb.AddForce(new Vector2(_rb.linearVelocity.x, jumpForce)); // เพิ่มแรงเมื่อกด spacebar เพื่อกระโดด
            Debug.Log("Jump");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
