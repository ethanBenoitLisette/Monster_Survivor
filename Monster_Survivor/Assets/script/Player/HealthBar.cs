using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    private Shop shop; // R�f�rence � la classe Shop

    private void Start()
    {
        // Trouver et attribuer la r�f�rence � la classe Shop
        shop = FindObjectOfType<Shop>();

        if (shop != null)
        {
            // Mettre � jour la valeur maximale de la barre de sant� en fonction de l'am�lioration de la vie
            healthBar.maxValue = shop.GetLifeUpgradeDamage();
            // Assurez-vous que la barre de sant� est correctement initialis�e
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
