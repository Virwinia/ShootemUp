
using UnityEngine;

public class EnemyShootingController : MonoBehaviour
{
    int fireRate;
    int bulletCounter;
    Shooting[] cannons;

    private void Start()
    {
        fireRate = GetComponent<NpcDataHandler>().fireRate;
        cannons = GetComponent<CannonController>().cannons;
    }

    private void Update()
    {
        bulletCounter++;
        if (bulletCounter % fireRate == 0)
        {
            EnemyShoot();
        }
    }


    void EnemyShoot()
    {
        for (int i = 0; i < cannons.Length; i++)
        {
            if (cannons[i].gameObject.activeInHierarchy)
                cannons[i].CreateEnemyProjectile();
        }
    }
}
