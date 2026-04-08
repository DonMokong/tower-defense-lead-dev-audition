using UnityEngine;
using System.Collections.Generic;

public class MultiTargetTower : TowerBase
{
    public GameObject projectilePrefab;
    public int maxTargets = 3;

    protected override void Fire()
    {
        List<EnemyController> enemies = GetEnemiesInRange();

        int count = Mathf.Min(maxTargets, enemies.Count);

        for (int i = 0; i < count; i++)
        {
            GameObject proj = Instantiate(
                projectilePrefab,
                transform.position,
                Quaternion.identity
            );

            proj.GetComponent<Projectile>().SetTarget(enemies[i]);
        }
    }
}