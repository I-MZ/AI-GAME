//�X���C���̏���

using UnityEngine;

public class Slime : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 5f;
    public float moveForce = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 0.5�b�ォ��1.5�b���ƂɃW�����v����
        InvokeRepeating("Jump", 0.5f, 1.5f);
    }

    private void Jump()
    {
        // ���񃉃��_���ō����E������
        int moveDirection = Random.Range(0, 2) == 0 ? -1 : 1;

        // ���������{������ɗ͂�������
        rb.velocity = new Vector2(moveDirection * moveForce, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // �_���[�W�ʂ�1
            }
        }
    }
}
