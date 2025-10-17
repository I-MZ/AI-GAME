//スコア管理のコード

using UnityEngine;
using TMPro; // ← 追加（TextMeshProを使うため）

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    public TextMeshProUGUI scoreText; // ← スコア表示用UIを指定

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
        UpdateScoreUI(); // 起動時にスコア初期表示
    }

    // スコア加算
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

    // スコア取得
    public int GetScore()
    {
        return score;
    }
}

