using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    bool isAutomatic = true;
    int fireRate;
    int bulletCounter;

    private void Start()
    {
        PlayerDataHandler playerData = GetComponent<PlayerDataHandler>();
        fireRate = playerData.fireRate;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootAttack.ShootAttackInstance.Shoot();
        }
        if (Input.GetMouseButton(0))
        {
            if (isAutomatic)
            {
                bulletCounter++;
                if (bulletCounter % fireRate == 0)
                {
                    ShootAttack.ShootAttackInstance.Shoot();
                }
            }
        }
    }

}
