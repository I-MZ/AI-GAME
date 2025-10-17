//�X�R�A�Ǘ��̃R�[�h

using UnityEngine;
using TMPro; // �� �ǉ��iTextMeshPro���g�����߁j

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    public TextMeshProUGUI scoreText; // �� �X�R�A�\���pUI���w��

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreUI(); // �N�����ɃX�R�A�����\��
    }

    // �X�R�A���Z
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // �X�R�A�擾
    public int GetScore()
    {
        return score;
    }
}

