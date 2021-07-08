using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    bool isAutomatic = true;
    int fireRate;
    int bulletCounter;
    Shooting[] cannons;

    private void Start()
    {
        fireRate = GetComponent<PlayerDataHandler>().fireRate;
        cannons = GetComponent<CannonController>().cannons;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButton(0))
        {
            if (isAutomatic)
            {
                bulletCounter++;
                if (bulletCounter % fireRate == 0)
                {
                    Shoot();
                }
            }
        }
    }


    void Shoot()
    {
        for (int i = 0; i < cannons.Length; i++)
        {
            if (cannons[i].gameObject.activeInHierarchy)
                cannons[i].CreateProjectile();
        }
    }
}
