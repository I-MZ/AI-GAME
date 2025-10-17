//剣の処理（敵を消す処理）

using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy defeated!");

            // スコア加算
            GameManager.Instance.AddScore(100);

            // 敵を消す
            Destroy(collision.gameObject);
        }
    }
}
