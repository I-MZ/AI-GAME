//�^�C�}�[UI�̃X�N���v�g

using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText; // UI�̎Q��
    private float elapsedTime = 0f;   // �o�ߎ���

    void Update()
    {
        // �o�ߎ��Ԃ����Z
        elapsedTime += Time.deltaTime;

        // �b�P�ʂŐ�����
        int displayTime = Mathf.FloorToInt(elapsedTime);

        // UI�ɕ\��
        timerText.text = "Time: " + displayTime + "s";
    }
}
