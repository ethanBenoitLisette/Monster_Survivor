using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    // Base stats for the enemy
    [SerializeField] private float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField] private float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField] private float damage;
    public float Damage { get => damage; private set => damage = value; }

    // Boosts for enemy stats
    [SerializeField] private float healthBoostPerLevel = 2f;
    [SerializeField] private float damageBoostPerLevel = 1f;

    public void ApplyLevelBoost(int currentLevel)
    {
        // Increase enemy health and damage based on current level and boost per level
        maxHealth += healthBoostPerLevel * currentLevel;
        damage += damageBoostPerLevel * currentLevel;
    }
}
