using UnityEngine;
using System.Collections; // Ajouter cette ligne pour résoudre l'erreur

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    private float currentMoveSpeed;
    private float currentHealth;
    private float currentDamage;
    private SpriteRenderer spriteRenderer;
    private Coroutine flashCoroutine;
    public int scoreValue = 1; 
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
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

        Color originalColor = spriteRenderer.color; // Stocker la couleur d'origine du sprite

        for (int i = 0; i < flashCount; i++)
        {
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Appliquer une couleur transparente
            yield return new WaitForSeconds(flashInterval);

            spriteRenderer.color = originalColor; // Rétablir la couleur d'origine
            yield return new WaitForSeconds(flashInterval);
        }

        spriteRenderer.color = originalColor; // Rétablir la couleur d'origine au cas où elle aurait été modifiée

        flashCoroutine = null;
    }

    public void Kill()
    {
        Destroy(gameObject);
        scoreManager.IncrementScore(scoreValue);
    }
}
