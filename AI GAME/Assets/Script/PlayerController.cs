//�v���C���[�̑���̃R�[�h

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;   // �����O�i�̑���
    public float jumpForce = 5f;   // �W�����v�̋���

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private int direction = 1;     // 1 = �E����, -1 = ������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �����O�i
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);

        // �����ύX�iA=��, D=�E�j
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = -1;
            transform.localScale = new Vector3(-1, 1, 1); // �����ڂ𔽓]
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }

        // �W�����v�iW�L�[�j
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // �n�ʔ���
    private void OnCollisionEnter2D(Collision2D collision)
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