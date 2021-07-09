
using UnityEngine;

public class EnemyShootingController : MonoBehaviour
{
    int mFireRate, mAmountCannons, bulletCounter;
    NpcDataHandler npcData;
    Shooting[] cannons;

    private void Start()
    {
        cannons = GetComponentsInChildren<Shooting>();
        npcData = GetComponent<NpcDataHandler>();
        mFireRate = npcData.fireRate;
        mAmountCannons = npcData.amountCannons;
    }

    private void Update()
    {
        bulletCounter++;
        if (bulletCounter % mFireRate == 0)
        {
            EnemyShoot();
        }
    }

    void EnemyShoot()
    {
        for (int i = 0; i < mAmountCannons; i++)
        {
            cannons[i].CreateEnemyProjectile();
        }
    }
}
