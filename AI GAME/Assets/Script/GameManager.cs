//スコア管理とゲームシーンからの移動のコード

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    private bool isGameOver = false;

    [Header("UI")]
    public GameObject gameOverUI;
    public TextMeshProUGUI scoreText; // 👈 スコアを表示するTMPテキストを追加！

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
                RestartGame();

            if (Input.GetKeyDown(KeyCode.T))
                ReturnToTitle();
        }
    }

    // スコア加算
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

        // 👇 スコアUIを更新する
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    // スコア取得
    public int GetScore()
    {
        return score;
    }

    // ゲームオーバー処理
    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("GAME OVER");

        if (gameOverUI != null)
            gameOverUI.SetActive(true);
    }

    // 現在のゲームを再スタート
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // タイトルに戻る
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}