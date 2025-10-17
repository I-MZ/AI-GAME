//プレイヤーの体力のUI管理

using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    public Image[] hearts; // ハートUI（♡の代わりに○）

    // 現在HPに応じてUIを更新
    public void UpdateHearts(int currentHP)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHP)
                hearts[i].enabled = true;  // 表示
            else
                hearts[i].enabled = false; // 非表示
        }
    }
}