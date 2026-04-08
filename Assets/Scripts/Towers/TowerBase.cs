using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    public float range = 5f;
    public float fireRate = 1f;

    protected float fireTimer;

    protected virtual void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            Fire();
            fireTimer = 0f;
        }
    }

    protected List<EnemyController> GetEnemiesInRange()
    {
        List<EnemyController> result = new List<EnemyController>();

        foreach (var enemy in EnemyManager.Instance.GetEnemies())
        {
            if (enemy == null) continue;

            float dist = Vector3.Distance(transform.position, enemy.transform.position);

            if (dist <= range)
            {
                result.Add(enemy);
            }
        }

        return result;
    }

    protected abstract void Fire();
}