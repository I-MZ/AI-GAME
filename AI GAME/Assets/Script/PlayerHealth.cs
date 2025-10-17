//プレイヤーのHP処理

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;   // 最大HP
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Game Over!");
        // TODO: ゲームオーバー処理をここに追加
        Destroy(gameObject); // とりあえずプレイヤーを消す
    }
}