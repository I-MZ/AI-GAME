//�v���C���[��HP����

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;   // �ő�HP
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
        // TODO: �Q�[���I�[�o�[�����������ɒǉ�
        Destroy(gameObject); // �Ƃ肠�����v���C���[������
    }
}