using UnityEngine;

public class FlecheBehaviour : ProjectileWeaponBehaviour
{
    public Shop shopManager; 

    protected override void Start()
    {
        base.Start();

        DirectionChecker(GetMouseWorldPosition());

        shopManager = FindObjectOfType<Shop>();
        if (shopManager == null)
        {
            Debug.LogError("ShopManager not found in the scene!");
        }
    }

    void Update()
    {

        transform.position += transform.right * currentSpeed * Time.deltaTime;

        if (shopManager != null)
        {
            currentDamage = shopManager.GetDistanceDamage();
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        // Obtenir la position du curseur dans le monde
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
