using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    private List<EnemyController> activeEnemies = new List<EnemyController>();

    void Awake()
    {
        Instance = this;
    }

    public void RegisterEnemy(EnemyController enemy)
    {
        activeEnemies.Add(enemy);
    }

    public void UnregisterEnemy(EnemyController enemy)
    {
        activeEnemies.Remove(enemy);
    }

    public List<EnemyController> GetEnemies()
    {
        return activeEnemies;
    }
}