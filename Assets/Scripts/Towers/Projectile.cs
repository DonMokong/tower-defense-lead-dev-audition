using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 5f;

    public float aoeRadius = 0f;

    private EnemyController target;

    public void SetTarget(EnemyController enemy)
    {
        target = enemy;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.transform.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.transform.position) < 0.2f)
        {
            HitTarget();
        }
    }

    void HitTarget()
    {
        if (aoeRadius > 0f)
        {
            ApplyAOEDamage();
        }
        else
        {
            target.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    void ApplyAOEDamage()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, aoeRadius);

        foreach (var hit in hits)
        {
            EnemyController enemy = hit.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}