
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    [SerializeField] PlayerSO playerData;
    [ReadOnly] public int health;

    [HideInInspector] public float speed;
    [HideInInspector] public int level, score, amountCannons, fireRate;
    [HideInInspector] public GameObject vfxDeath;
    [HideInInspector] public GameObject objPlayer;

    // [HideInInspector] public Sprite playerSprite;
    // [HideInInspector] public int scoreMax; // FUTURE ME: INTENTA REFERENCIAR UN SCRIPTABLE OBJECT QUE SÓLO CONTENGA SCORE


    private void Awake()
    {
        // playerSprite = playerData.playerShip; --- not used
        // level = playerData.level; --- not used

        // PLAYER DATA
        score = playerData.Score;
        speed = playerData.speed;
        health = playerData.health;

        // PLAYER SHIP DATA
        objPlayer = playerData.Player;
        amountCannons = playerData.cannonAmount;
        fireRate = playerData.fireRate;
        vfxDeath = playerData.ExplosionDeath;

    }
}
