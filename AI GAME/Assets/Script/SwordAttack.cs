//���̏����i�G�����������j

using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy defeated!");

            // �X�R�A���Z
            GameManager.Instance.AddScore(100);

            // �G������
            Destroy(collision.gameObject);
        }
    }
}
