
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    public static PlayerDataHandler playerDataInstance;

    [SerializeField] PlayerSO playerData;
    [SerializeField] public GameObject shield;

    [HideInInspector] public int health;
    public float speed;
    public int score, amountCannons, fireRate;
    [HideInInspector] public GameObject vfxDeath;
    [HideInInspector] public GameObject objPlayer;
    [HideInInspector] public bool hasShield;
    float startingSpeed;

    private void Awake()
    {
        playerDataInstance = this;

        // PLAYER DATA
        score = playerData.Score;
        speed = playerData.speed;
        startingSpeed = speed;
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

    public float StartingSpeed
    {
        get { return startingSpeed; }
    }

    // INFINITE SHIELD CHEAT
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
