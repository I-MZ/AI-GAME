//スライムの処理

using UnityEngine;

public class Slime : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 5f;
    public float moveForce = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 0.5秒後から1.5秒ごとにジャンプする
        InvokeRepeating("Jump", 0.5f, 1.5f);
    }

    private void Jump()
    {
        // 毎回ランダムで左か右を決定
        int moveDirection = Random.Range(0, 2) == 0 ? -1 : 1;

        // 水平方向＋上方向に力を加える
        rb.velocity = new Vector2(moveDirection * moveForce, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // ダメージ量は1
            }
        }
    }
}
