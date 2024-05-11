using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public int playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().currentHealth;
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth;
        healthBar.value = playerHealth;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
