//プレイヤーの操作のコード

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed = 2f;   // 自動前進の速さ
    public float jumpForce = 5f;   // ジャンプ力

    [Header("剣")]
    public Transform sword;        // 剣のTransform（プレイヤーの子オブジェクト）

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded = false;
    private int direction = 1;     // 1=右向き, -1=左向き
    private Vector3 swordOriginalScale;
    private Vector3 swordOriginalPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // Rigidbody2D 設定
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // 剣の元サイズと位置を保持
        if (sword != null)
        {
            swordOriginalScale = sword.localScale;
            swordOriginalPosition = sword.localPosition;
        }
    }

    void Update()
    {
        // 自動前進
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);

        // 向き変更
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

        // ジャンプ（Tag 判定）
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Y速度リセット
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // 剣の反転（位置とサイズ）
    void FlipSword()
    {
        if (sword == null) return;

        // localScale の反転
        Vector3 s = swordOriginalScale;
        s.x = Mathf.Abs(s.x) * direction;
        sword.localScale = s;

        // localPosition の反転（Pivot が手の付け根にある前提）
        Vector3 p = swordOriginalPosition;
        p.x = Mathf.Abs(swordOriginalPosition.x) * direction;
        sword.localPosition = p;
    }

    // 接地判定（Tag 判定）
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
    public float moveSpeed = 2f;   // 自動前進の速さ
    public float jumpForce = 5f;   // ジャンプの強さ

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private int direction = 1;     // 1 = 右向き, -1 = 左向き

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 自動前進
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);

        // 向き変更（A=左, D=右）
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = -1;
            transform.localScale = new Vector3(-1, 1, 1); // 見た目を反転
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }

        // ジャンプ（Wキー）
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // 地面判定
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