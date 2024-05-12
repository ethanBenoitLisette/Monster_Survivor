using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] private float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField] private float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField] private float damage;
    public float Damage { get => damage; private set => damage = value; }

    [SerializeField] private float healthBoostPerLevel = 2f;
    [SerializeField] private float damageBoostPerLevel = 1f;

    public void ApplyLevelBoost(int currentLevel)
    {
        maxHealth += healthBoostPerLevel * currentLevel;
        damage += damageBoostPerLevel * currentLevel;
    }
}
