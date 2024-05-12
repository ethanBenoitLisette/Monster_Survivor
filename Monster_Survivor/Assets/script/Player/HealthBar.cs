using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    private Shop shop; 

    private void Start()
    {
        shop = FindObjectOfType<Shop>();

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

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
