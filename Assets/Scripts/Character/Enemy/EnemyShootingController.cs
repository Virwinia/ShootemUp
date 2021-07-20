
using UnityEngine;

public class EnemyShootingController : MonoBehaviour
{
    int mFireRate, mAmountCannons, bulletCounter;
    NpcDataHandler npcData;
    CannonController cannonController;
    // [ReadOnly] [SerializeField] Shooting[] cannons; //----> I think cannonController is better option - Test

    private void Start()
    {
        // cannons = GetComponentsInChildren<Shooting>();
        cannonController = GetComponent<CannonController>();
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
        if (cannonController != null)
            for (int i = 0; i < mAmountCannons; i++)
            {
                cannonController.cannons[i].CreateEnemyProjectile();
            }
    }
}
