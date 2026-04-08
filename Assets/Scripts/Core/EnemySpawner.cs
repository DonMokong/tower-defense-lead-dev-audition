using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform spawnPoint;
    public Transform target;

    public EnemyStats[] enemyTypes;

    public float spawnInterval = 2f;

    float timer;

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
        GameObject enemyObj = Instantiate(
            enemyPrefab,
            spawnPoint.position,
            Quaternion.identity
        );

        EnemyController enemy = enemyObj.GetComponent<EnemyController>();

        enemy.target = target;
        enemy.stats = enemyTypes[Random.Range(0, enemyTypes.Length)];
    }
}