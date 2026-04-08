using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStats stats;
    public Transform target;

    public GameObject hitVFX;
    public GameObject deathVFX;

    private float currentHealth;

    void Start()
    {
        currentHealth = stats.maxHealth;
        EnemyManager.Instance.RegisterEnemy(this);
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            stats.moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            ReachTarget();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (hitVFX != null)
        {
            Instantiate(hitVFX, transform.position, Quaternion.identity);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void ReachTarget()
    {
        GameManager.Instance.DamageTarget(stats.damageToTarget);
        Die();
    }

    void Die()
    {
        if (deathVFX != null)
        {
            Instantiate(deathVFX, transform.position, Quaternion.identity);
        }

        EnemyManager.Instance.UnregisterEnemy(this);
        GameManager.Instance.AddScore(stats.scoreValue);

        Destroy(gameObject);
    }
}