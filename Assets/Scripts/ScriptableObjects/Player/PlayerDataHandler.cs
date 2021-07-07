
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    [SerializeField] PlayerSO playerData;
    [ReadOnly] public Sprite playerSprite;
    [ReadOnly] public float speed;
    [ReadOnly] public int level, health, amountCannons, fireRate;

    private void Awake()
    {
        playerSprite = playerData.playerShip;
        level = playerData.level;
        speed = playerData.speed;
        health = playerData.health;
        amountCannons = playerData.cannonAmount;
        fireRate = playerData.fireRate;
    }
}
