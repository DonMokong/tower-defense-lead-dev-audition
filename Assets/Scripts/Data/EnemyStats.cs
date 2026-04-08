using UnityEngine;

[CreateAssetMenu(menuName = "TD/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public float maxHealth = 10f;
    public float moveSpeed = 2f;
    public int damageToTarget = 1;
    public int scoreValue = 10;
}