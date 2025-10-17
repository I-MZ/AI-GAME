//タイマーUIのスクリプト

using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText; // UIの参照
    private float elapsedTime = 0f;   // 経過時間

    void Update()
    {
        // 経過時間を加算
        elapsedTime += Time.deltaTime;

        // 秒単位で整数に
        int displayTime = Mathf.FloorToInt(elapsedTime);

        // UIに表示
        timerText.text = "Time: " + displayTime + "s";
    }
}
