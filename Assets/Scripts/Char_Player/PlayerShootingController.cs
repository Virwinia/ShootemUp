using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    bool isAutomatic = true;
    int fireRate;
    int bulletCounter;
    int activeCannons;
    Shooting[] cannons;


    private void Start()
    {
        PlayerDataHandler playerData = GetComponent<PlayerDataHandler>();
        fireRate = playerData.fireRate;
        activeCannons = playerData.amountCannons;

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
                if (bulletCounter % fireRate == 0)
                {
                    Shoot();
                }
            }
        }
    }


    void Shoot()
    {
        for (int i = 0; i < activeCannons; i++)
            cannons[i].CreateProjectile();

    }
}
