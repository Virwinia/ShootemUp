
using UnityEngine;

public class ShootAttack : MonoBehaviour
{
    public static ShootAttack ShootAttackInstance;
    CannonHandler cannonHandler;

    private void Awake()
    {
        ShootAttackInstance = this;
    }

    private void Start()
    {
        cannonHandler = GetComponent<CannonHandler>();
    }

    public void Shoot()
    {
        foreach (Shooting shooting in cannonHandler.cannons)
        {
            if (shooting.gameObject.activeInHierarchy)
                shooting.CreateProjectile();
        }
    }
}
