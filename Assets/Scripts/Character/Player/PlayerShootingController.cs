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
        PrepareCannonToShoot();
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

    /* 
        HOW CANNONS WORK ----
        
        1. First, the Player takes from playerData the amount of cannons which can be used.
        2. Then, the cannons to be used are activated (SetActiveTrue) in CannonController. Remaining are disabled.
        3. Finally, actived cannons need to be said they are active ---> required method is ActivateCannonsToFire()
       
        NOTE: if the player activates new cannons in gameplay, is a MUST to call both,
            CannonController > ActivateNewCannons(x) 
            and PlayerShooting > PrepareCannonToShoot(), in this given order.
    */
    public void PrepareCannonToShoot()
    {
        cannons = GetComponentsInChildren<Shooting>();
    }

    void Shoot()
    {
        for (int i = 0; i < PlayerDataHandler.playerDataInstance.amountCannons; i++)
            cannons[i].CreateProjectile();
    }
}
