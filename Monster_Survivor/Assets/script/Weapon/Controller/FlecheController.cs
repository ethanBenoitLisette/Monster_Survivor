using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlecheController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedFleche = Instantiate(weaponData.Prefab);
        spawnedFleche.transform.position = transform.position; 
        spawnedFleche.GetComponent<FlecheBehaviour>().DirectionChecker(pm.lastMovedVector);
    }
}