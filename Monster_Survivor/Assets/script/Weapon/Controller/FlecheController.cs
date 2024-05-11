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
        spawnedFleche.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedFleche.GetComponent<FlecheBehaviour>().DirectionChecker(pm.lastMovedVector);   //Reference and set the direction
    }
}