//スコア管理とゲームシーンからの移動のコード

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    private bool isGameOver = false;

    [Header("UI（ゲームオーバー時に表示）")]
    public GameObject gameOverUI;

    [Header("制限時間（秒）")]
    public float timeLimit = 180f; // 180秒でリザルトへ
    private float timer = 0f;

    void Awake()
    {
        // シングルトン設定
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ← これを追加！（シーンをまたいでも残る）
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isGameOver) return;

        // 経過時間
        timer += Time.deltaTime;

        if (timer >= timeLimit)
        {
            GoToResult();
        }

        if (Input.GetKeyDown(KeyCode.R))
            ReturnToTitle();

        // Rキーでリスタート
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        // Tキーでタイトルへ
        if (Input.GetKeyDown(KeyCode.T))
        {
            ReturnToTitle();
        }
    }

    // スコア加算
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public int GetScore()
    {
        return score;
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

    public void GoToResult()
    {
        Debug.Log("制限時間終了！リザルトへ移動します");
        SceneManager.LoadScene("ResultScene");
    }
}

/*
using UnityEngine;
using TMPro; // スコアやUI表示に使用
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    private bool isGameOver = false; // ゲームオーバー中かどうか

    [Header("UI")]
    public GameObject gameOverUI; // ゲームオーバー時に表示されるUI
    public TextMeshProUGUI scoreText; // スコア表示用UI

    void Awake()
    {
        // シングルトン（どこからでも呼び出せるようにする）
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンを跨いでも消えないようにする
        }
        else
        {
            Destroy(gameObject); // 複製を防ぐ
        }
    }

    void Update()
    {
        // ゲームオーバー中のみキー操作を受け付ける
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("R pressed → RestartGame()");
                RestartGame();
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("T pressed → ReturnToTitle()");
                ReturnToTitle();
            }
        }

        // テスト用：キー入力検知ログ（あとで削除してOK）
        if (Input.GetKeyDown(KeyCode.R))
            Debug.Log("R key detected (even if not game over)");
        if (Input.GetKeyDown(KeyCode.T))
            Debug.Log("T key detected (even if not game over)");
    }

    // スコア加算
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

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
        Debug.Log("GAME OVER!");

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // UIを表示
            Debug.Log("GameOverUI Activated!");
        }
        else
        {
            Debug.LogWarning("⚠ GameOverUI が設定されていません！");
        }
    }

    // 現在のゲームを再スタート
    public void RestartGame()
    {
        Debug.Log("Restarting current scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // タイトルシーンに戻る
    public void ReturnToTitle()
    {
        Debug.Log("Returning to TitleScene...");
        SceneManager.LoadScene("TitleScene");
    }
}
*/