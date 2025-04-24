using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float JumpPower = 10f;
    [SerializeField] private float Distance = 0.01f;
    [SerializeField] private Vector2 Direction = new Vector2(0,-0.45f);
    [SerializeField] private Vector2 WallDirection;
    [SerializeField] private LayerMask layer;
    [SerializeField] private bool isGround;
    [SerializeField] private bool isWall;
    bool canMove = true;
    private float moveInput; // ����/������ �Է¸�
    

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Input System���� �ڵ� ȣ��
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();
        if (Input.anyKey)
        {
            transform.localScale = new Vector3(moveInput == 0 ? transform.localScale.x : moveInput > 0 ? 1 : -1, 1, 1);
        }
    }

    //�� ������ ���� ���̶�� ���� �����̸� 6ĭ �پ���ƾ��Ѵ�
    public void OnJump()
    {
        if(Input.anyKeyDown)
        {
            if (isGround)
            {
                rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                Debug.Log("jump");
            }
            else
            {
                if (isWall)
                {
                    rb.velocity = Vector2.zero;
                    WallJump();
                    Debug.Log("Success");
                }
            }
        }
    }

    void isSliding()
    {
        if(!isGround && isWall && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -1f);
        }
    }

    void WallJump()
    {
        float walljump = -transform.localScale.x;
        StartCoroutine(wallJump(walljump * (JumpPower + 5), JumpPower + 1.5f));
        Debug.Log(rb.velocity);

        transform.localScale = new Vector3(walljump, 1, 1);

        isWall = false;
        canMove = false;
        StartCoroutine(WaitAction.wait(0.15f, () => canMove = true));
    }

    IEnumerator wallJump(float x, float y)
    {
        for(int i = 0; i < 5; i++)
        {
            rb.velocity = new Vector2(x, y) * 1.5f;
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void FixedUpdate()
    {
        if(canMove)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
        Bounds bounds = GetComponent<Collider2D>().bounds;
        RaycastHit2D hit = Physics2D.Raycast(rb.position + Direction, Vector2.down * Distance, Distance, layer);
        isWall = Physics2D.BoxCast(transform.position, bounds.size, 0f, Vector2.right * transform.localScale.x * Direction, Distance, layer);
        isGround = hit.collider != null;
        isSliding();
        Debug.Log(moveInput);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position + (Vector3)Direction, Vector2.down * Distance);
    }
}
