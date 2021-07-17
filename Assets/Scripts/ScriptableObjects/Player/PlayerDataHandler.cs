
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    [SerializeField] PlayerSO playerData;
    [ReadOnly] public int health;
    [HideInInspector] public float speed;
    [HideInInspector] public int level, score, amountCannons, fireRate;
    [HideInInspector] public GameObject vfxDeath;
    [HideInInspector] public GameObject objPlayer;
    [Space] [SerializeField] public bool hasShield;
    [SerializeField] public GameObject shield;

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

        hasShield = false;
        shield.SetActive(hasShield);
    }

    // private void Update()
    // {
    //     // Cheat Shield Up/Down
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         if (!hasShield)
    //         {
    //             print("true");
    //             hasShield = true;
    //         }
    //         else
    //         {
    //             print("false");
    //             hasShield = false;
    //         }
    //         shield.SetActive(hasShield);
    //     }
    // }

    public void ShieldActivation(bool isActivated)
    {
        shield.SetActive(isActivated);
        hasShield = isActivated;
    }




}
