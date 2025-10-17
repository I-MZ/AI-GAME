//敵を出現させる（場所はランダム）コード

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // 出現させる敵（SlimeのPrefab）
    public Transform player;         // プレイヤーをInspectorで指定

    public float spawnInterval = 2f; // 出現間隔（秒）
    public float spawnRangeX   = 8f; // 横の出現範囲
    public float safeRange     = 2f; // 出現禁止の範囲（X座標の距離）


    private float timer;

    void Update()
    {
        // プレイヤーがいなくなったらスポーン処理を止める
        if (player == null) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (player == null) return; // 念のためチェック

        float randomX;

        // プレイヤーの近くを避ける処理
        do
        {
            randomX = Random.Range(-spawnRangeX, spawnRangeX);
        }
        while (Mathf.Abs(randomX - player.position.x) < safeRange);

        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}