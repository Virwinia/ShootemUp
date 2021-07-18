
public class APickPowerUp : AbstractPickItem
{
    int id;
    PlayerDataHandler playerData;
    bool hasPickedHealth = false;
    bool hasPîckedShield = false;
    bool hasPickedBolt = false;

    private void Start()
    {
        id = itemData.id;
    }

    void TriggerPowerUpEffect()
    {
        switch (id)
        {
            case 23:
                print("Whadya want?");
                break;
            case 22:
                // Bolt - more cannons + speed
                IncreaseSpeedAndImproveShooting();
                break;
            case 21:
                // Health
                IncreasePlayerAmountOfLifes();
                break;
            case 20:
                // Get shield
                PlayerDataHandler.playerDataInstance.ShieldActivation(true);
                hasPîckedShield = true;
                break;
            default:
                break;
        }
    }

    public override void DoSomething()
    {
        TriggerPowerUpEffect();
    }

    public override bool PowerUpIsPickable()
    {
        switch (id)
        {
            case 22:
                return hasPickedBolt;
            case 21:
                return hasPickedHealth;
            case 20:
                return hasPîckedShield;
            default:
                break;
        }
        return false;
    }

    void IncreaseSpeedAndImproveShooting()
    {
        PlayerDataHandler player = PlayerDataHandler.playerDataInstance;
        if (player.amountCannons >= 5 && player.speed >= player.StartingSpeed * 1.5f)
            hasPickedBolt = false;
        else
        {
            hasPickedBolt = true;

            // Increase stats in PlayerDataHandler
            if (player.amountCannons < 5)
                player.amountCannons = player.amountCannons + 2;

            if (player.StartingSpeed > player.speed)
                player.speed = player.speed + (player.StartingSpeed * 0.3f);

            // Update new speed stat in those scripts required for player movement
            if (player.GetComponent<PlayerMovement_J>().isActiveAndEnabled)
                player.GetComponent<PlayerMovement_J>().SetSpeedInPlayer();
            else player.GetComponent<PlayerMovement_K>().SetSpeedInPlayer();

            // Update new amount of cannons stat in those scripts required for shooting
            player.GetComponent<CannonController>().ActivateCannons(player.amountCannons);
            player.GetComponent<PlayerShootingController>().PrepareCannonToShoot();
        }

    }

    void IncreasePlayerAmountOfLifes()
    {
        int currentHealth = GameManager.gameManagerInstance.playerHealth;
        int startingHealth = PlayerDataHandler.playerDataInstance.health;
        if (startingHealth > currentHealth)
        {
            GameManager.gameManagerInstance.playerHealth++;
            hasPickedHealth = true;
        }
    }


}
