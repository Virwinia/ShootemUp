using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    bool isAutomatic = true;
    int bulletCounter;
    Shooting[] cannons;


    private void Start()
    {
        cannons = GetComponentsInChildren<Shooting>();
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
                if (bulletCounter % PlayerDataHandler.playerDataInstance.fireRate == 0)
                {
                    Shoot();
                }
            }
        }
    }


    void Shoot()
    {
        for (int i = 0; i < PlayerDataHandler.playerDataInstance.amountCannons; i++)
            cannons[i].CreateProjectile();

    }
}
