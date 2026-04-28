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
        if (Keyboard.current != null)
        {
            moveValue = (Keyboard.current.dKey.isPressed ? 1f : 0) - (Keyboard.current.aKey.isPressed ? 1f : 0);
        }

        if (moveValue != 0) 
        {
            _rb.linearVelocity = new Vector2(moveValue * speed, _rb.linearVelocity.y); 
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded) 
        {
            _rb.AddForce(new Vector2(_rb.linearVelocity.x, jumpForce)); 
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
