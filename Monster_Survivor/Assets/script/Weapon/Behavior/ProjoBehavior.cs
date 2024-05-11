using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjoBehaviour : ProjectileWeaponBehaviour
{
    private Transform player;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.right = direction;
        }
    }

    void Update()
    {
        transform.position += transform.right * currentSpeed * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerMovement playerStats = col.GetComponent<PlayerMovement>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(Mathf.RoundToInt(currentDamage));
            }
        }
    }
}
