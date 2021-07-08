
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    [SerializeField] PlayerSO playerData;
    [ReadOnly] int health;
    [HideInInspector] public Sprite playerSprite;
    [HideInInspector] public float speed;
    [HideInInspector] public int level, amountCannons, fireRate;

    private void Awake()
    {
        // playerSprite = playerData.playerShip; --- not used
        // level = playerData.level; --- not used
        speed = playerData.speed;   // ShipMovement
        // health = playerData.health; --- not used
        amountCannons = playerData.cannonAmount; // CannonController
        fireRate = playerData.fireRate; // PlayerShootingController
    }
}
