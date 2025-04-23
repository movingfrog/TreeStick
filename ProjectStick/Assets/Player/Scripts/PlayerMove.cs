using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float JumpPower = 10f;
    [SerializeField] private float Distance;
    [SerializeField] private Vector2 Direction;
    [SerializeField] private LayerMask layer;
    private float moveInput; // ����/������ �Է¸�
    private bool isGround;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Input System���� �ڵ� ȣ��
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();
    }

    public void OnJump()
    {
        if(isGround)
        {
            rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        RaycastHit2D hit = Physics2D.Raycast(rb.position + Direction, Vector2.down * Distance, Distance, layer);
        isGround = hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position + (Vector3)Direction, Vector2.down * Distance);
    }
}
