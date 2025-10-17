//プレイヤーのHP処理

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    public PlayerHPUI hpUI; // HP UI への参照

    void Start()
    {
        currentHP = maxHP;
        hpUI.UpdateHearts(currentHP); // 初期表示
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        hpUI.UpdateHearts(currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Game Over!");
        Destroy(gameObject); // プレイヤーを消す
    }
}