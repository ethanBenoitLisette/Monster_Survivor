using System.Collections;
using UnityEngine;

public class EpeeController : WeaponController
{
    public float rotationSpeed = 90f; 
    public GameObject player;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedEpee = Instantiate(weaponData.Prefab);
        spawnedEpee.transform.position = transform.position; 
        spawnedEpee.transform.parent = transform;
        
        RotateEpee(spawnedEpee);
    }

    void RotateEpee(GameObject Epee)
    {
        StartCoroutine(RotateForDuration(Epee));
    }

    IEnumerator RotateForDuration(GameObject Epee)
    {
        while (Epee != null)
        {
            Epee.transform.RotateAround(player.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
