using UnityEngine;

public class Enemydistance : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float shootingInterval = 1f;
    public GameObject projectilePrefab;
    public float fireDistance = 10f; 
    private GameObject player;
    private bool isInRange = false; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("ShootAtPlayer", shootingInterval, shootingInterval);
    }

    private void Update()
    {
        if (!isInRange)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void ShootAtPlayer()
    {
        if (player != null && Vector3.Distance(transform.position, player.transform.position) <= fireDistance)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            isInRange = true; // Le joueur est à portée de tir, donc arrête de bouger
        }
        else {
            isInRange = false;


        }
    }
}
