//�X�R�A�Ǘ��̃R�[�h

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;

    void Awake()
    {
        // �V���O���g���i�ǂ�����ł��Ăׂ�悤�ɂ���j
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �X�R�A���Z
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score); // �f�o�b�O�Ŋm�F
    }

    // �X�R�A�擾
    public int GetScore()
    {
        return score;
    }
}
