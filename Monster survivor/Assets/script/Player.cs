using UnityEngine;

public class MonsterSurvivorMovement : MonoBehaviour
{
    public float speed = 5f; 

    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalMovement * speed * Time.deltaTime);

        float verticalMovement = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalMovement * speed * Time.deltaTime);
    }
}
