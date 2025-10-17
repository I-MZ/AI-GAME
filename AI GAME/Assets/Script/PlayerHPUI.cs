//プレイヤーの体力のUI管理

using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    public Image[] hearts; //ハートUI（Inspectorで3つ入れる）

    // HPを設定する（0〜hearts.Length）
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