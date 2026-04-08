using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform target;

    public float spawnInterval = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        GameObject enemyObj = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        EnemyController enemy = enemyObj.GetComponent<EnemyController>();
        enemy.target = target;
    }
}