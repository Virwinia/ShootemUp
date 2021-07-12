
using UnityEngine;

public class EnemyShootingController : MonoBehaviour
{
    int mFireRate, mAmountCannons, bulletCounter;
    [ReadOnly] [SerializeField] NpcDataHandler npcData;
    // [ReadOnly] [SerializeField] Shooting[] cannons;
    [ReadOnly] [SerializeField] CannonController cannonController;

    private void Start()
    {
        cannonController = GetComponent<CannonController>();
        // cannons = GetComponentsInChildren<Shooting>();
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
