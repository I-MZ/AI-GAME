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
    public TextMeshProUGUI scoreText;
    public GameObject gameOverUI;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI(); // ← 起動時に初期スコア表示
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

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI(); // ← スコアUI更新
        Debug.Log("Score: " + score);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("GAME OVER");
        if (gameOverUI != null)
            gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}