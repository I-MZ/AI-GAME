//�v���C���[�̑���̃R�[�h

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�ړ��ݒ�")]
    public float moveSpeed = 2f;   // �����O�i�̑���
    public float jumpForce = 5f;   // �W�����v��

    [Header("��")]
    public Transform sword;        // ����Transform�i�v���C���[�̎q�I�u�W�F�N�g�j

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded = false;
    private int direction = 1;     // 1=�E����, -1=������
    private Vector3 swordOriginalScale;
    private Vector3 swordOriginalPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // Rigidbody2D �ݒ�
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // ���̌��T�C�Y�ƈʒu��ێ�
        if (sword != null)
        {
            swordOriginalScale = sword.localScale;
            swordOriginalPosition = sword.localPosition;
        }
    }

    void Update()
    {
        // �����O�i
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);

        // �����ύX
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = -1;
            sr.flipX = true;
            FlipSword();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 1;
            sr.flipX = false;
            FlipSword();
        }

        // �W�����v�iTag ����j
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Y���x���Z�b�g
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // ���̔��]�i�ʒu�ƃT�C�Y�j
    void FlipSword()
    {
        if (sword == null) return;

        // localScale �̔��]
        Vector3 s = swordOriginalScale;
        s.x = Mathf.Abs(s.x) * direction;
        sword.localScale = s;

        // localPosition �̔��]�iPivot ����̕t�����ɂ���O��j
        Vector3 p = swordOriginalPosition;
        p.x = Mathf.Abs(swordOriginalPosition.x) * direction;
        sword.localPosition = p;
    }

    // �ڒn����iTag ����j
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

/*
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
*/