using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    private float currentMoveSpeed;
    private float currentHealth;
    private float currentDamage;
    private SpriteRenderer spriteRenderer;
    private Coroutine flashCoroutine;
    private ScoreManager scoreManager;
    private EnemySpawner enemySpawner;
    private Shop shop;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        shop = FindObjectOfType<Shop>();
    }

    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Kill();
        }
        else
        {
            if (flashCoroutine == null)
            {
                flashCoroutine = StartCoroutine(FlashCoroutine());
            }
        }
    }

    private IEnumerator FlashCoroutine()
    {
        float flashDuration = 0.5f;
        int flashCount = 5;
        float flashInterval = flashDuration / flashCount;

        Color originalColor = spriteRenderer.color; 

        for (int i = 0; i < flashCount; i++)
        {
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
            yield return new WaitForSeconds(flashInterval);

            spriteRenderer.color = originalColor; 
            yield return new WaitForSeconds(flashInterval);
        }

        spriteRenderer.color = originalColor; 

        flashCoroutine = null;
    }

    public void Kill()
    {
        Debug.Log(shop.GetMoneyDamage());
        Debug.Log(shop.GetDistanceDamage());
        Destroy(gameObject);
        scoreManager.IncrementScore(shop.GetMoneyDamage());
        enemySpawner.EnemyKilled();
    }

}
