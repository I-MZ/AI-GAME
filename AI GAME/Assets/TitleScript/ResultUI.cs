using UnityEngine;
using TMPro;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        // GameManager�̃X�R�A���擾���ĕ\��
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
