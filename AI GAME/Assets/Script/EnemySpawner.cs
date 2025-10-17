//�G���o��������i�ꏊ�̓����_���j�R�[�h

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // �o��������G�iSlime��Prefab�j
    public Transform player;         // �v���C���[��Inspector�Ŏw��

    public float spawnInterval = 2f; // �o���Ԋu�i�b�j
    public float spawnRangeX   = 8f; // ���̏o���͈�
    public float safeRange     = 2f; // �o���֎~�͈̔́iX���W�̋����j


    private float timer;

    void Update()
    {
        // �v���C���[�����Ȃ��Ȃ�����X�|�[���������~�߂�
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
        if (player == null) return; // �O�̂��߃`�F�b�N

        float randomX;

        // �v���C���[�̋߂�������鏈��
        do
        {
            randomX = Random.Range(-spawnRangeX, spawnRangeX);
        }
        while (Mathf.Abs(randomX - player.position.x) < safeRange);

        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}