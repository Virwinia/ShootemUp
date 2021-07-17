
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    public static PlayerDataHandler playerDataInstance;

    [SerializeField] PlayerSO playerData;
    [SerializeField] public GameObject shield;
    [ReadOnly] public int health;

    [HideInInspector] public float speed;
    [HideInInspector] public int score, amountCannons, fireRate;
    [HideInInspector] public GameObject vfxDeath;
    [HideInInspector] public GameObject objPlayer;
    [HideInInspector] public bool hasShield;

    private void Awake()
    {
        playerDataInstance = this;

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

    public void ShieldActivation(bool isActivated)
    {
        shield.SetActive(isActivated);
        hasShield = isActivated;
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


}
