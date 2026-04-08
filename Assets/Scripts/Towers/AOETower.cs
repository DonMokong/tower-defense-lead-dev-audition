using UnityEngine;
using System.Collections.Generic;

public class AOETower : TowerBase
{
    public GameObject projectilePrefab;

    protected override void Fire()
    {
        List<EnemyController> enemies = GetEnemiesInRange();

        if (enemies.Count == 0)
            return;

        EnemyController target = enemies[0];

        GameObject proj = Instantiate(
            projectilePrefab,
            transform.position,
            Quaternion.identity
        );

        proj.GetComponent<Projectile>().SetTarget(target);
    }
}