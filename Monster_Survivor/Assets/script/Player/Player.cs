using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Slider healthBar;
    public float moveSpeed;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    public Vector2 lastMovedVector;
    public GameObject losePanel;

    private Rigidbody2D rb;
    private Shop shop; // Référence à la classe Shop

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);

        // Trouver et attribuer la référence à la classe Shop
        shop = FindObjectOfType<Shop>();

        // Assurez-vous que la barre de santé est correctement configurée en fonction de l'amélioration de la vie
        if (shop != null)
        {
            healthBar.maxValue = shop.GetLifeUpgradeDamage();
            healthBar.value = healthBar.maxValue;
        }
        else
        {
            Debug.LogError("Shop component not found!");
        }
    }

    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);    //Last moved X
        }

        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);  //Last moved Y
        }

        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);    //While moving
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

    public void TakeDamage(int damage)
    {
        healthBar.value -= damage;

        if (healthBar.value <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }
}
