using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    private Shop shop; // Référence à la classe Shop

    private void Start()
    {
        // Trouver et attribuer la référence à la classe Shop
        shop = FindObjectOfType<Shop>();

        if (shop != null)
        {
            // Mettre à jour la valeur maximale de la barre de santé en fonction de l'amélioration de la vie
            healthBar.maxValue = shop.GetLifeUpgradeDamage();
            // Assurez-vous que la barre de santé est correctement initialisée
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
