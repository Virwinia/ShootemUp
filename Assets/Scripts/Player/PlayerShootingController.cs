using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    // Shooting[] bullets;
    [SerializeField] bool isAutomatic;
    int fireRate;
    int bulletCounter;

    // private void Awake()
    // {
    //     bullets = GetComponentsInChildren<Shooting>();
    // }
    private void OnEnable()
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


    // public void Shoot()
    // {
    //     foreach (Shooting shooting in bullets)
    //     {
    //         shooting.CreateProjectile();
    //     }
    // }
}
