using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    private PlayerMovement playerMovement;
    

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>(); // Trouver le script PlayerMovement dans la scène
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerMovement.transform.position, enemyData.MoveSpeed * Time.deltaTime);  
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int damage = Mathf.RoundToInt(enemyData.Damage); 
            playerMovement.TakeDamage(damage); 
        }
    }
}
