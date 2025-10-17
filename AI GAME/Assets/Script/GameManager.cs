//スコア管理のコード

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;

    void Awake()
    {
        // シングルトン（どこからでも呼べるようにする）
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // スコア加算
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score); // デバッグで確認
    }

    // スコア取得
    public int GetScore()
    {
        return score;
    }
}
