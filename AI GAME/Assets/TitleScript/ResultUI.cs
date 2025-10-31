using UnityEngine;
using TMPro;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        // GameManagerのスコアを取得して表示
        if (GameManager.Instance != null)
        {
            int score = GameManager.Instance.GetScore();
            scoreText.text = "SCORE : " + score.ToString();
        }
        else
        {
            scoreText.text = "SCORE : 0";
        }
    }
}
