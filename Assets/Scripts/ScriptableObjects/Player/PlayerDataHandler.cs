
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    [SerializeField] PlayerSO playerData;
    [ReadOnly] public int health;
    // [HideInInspector] public Sprite playerSprite;
    [HideInInspector] public float speed;
    [HideInInspector] public int level, amountCannons, fireRate;
    [HideInInspector] public GameObject vfxDeath;
    [HideInInspector] public GameObject player;
    // [HideInInspector] public int score;
    [HideInInspector] public int scoreMax; // FUTURE ME: INTENTA REFERENCIAR UN SCRIPTABLE OBJECT QUE SÓLO CONTENGA SCORE


    private void Awake()
    {
        // playerSprite = playerData.playerShip; --- not used
        // level = playerData.level; --- not used
        speed = playerData.speed;   // ShipMovement
        health = playerData.health;
        amountCannons = playerData.cannonAmount; // CannonController
        fireRate = playerData.fireRate; // PlayerShootingController
        vfxDeath = playerData.ExplosionDeath;
        player = playerData.Player;
    }
}
