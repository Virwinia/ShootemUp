
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If has not shield, the Player dies on collision with any npc.
        if (!PlayerDataHandler.playerDataInstance.hasShield)
            if (collision.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_ENEMY) ||
               collision.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_ROCK))
            {
                PlayerDeath();
            }
    }

    public void PlayerDeath()
    {
        // GameManager reduces 1 life from PlayerData
        GameManager.gameManagerInstance.RemovePlayerHealth();
        // Plays sound and particles for PlayerDeath
        AudioManager.audioManagerInstance.PlaySound(3);
        Instantiate(PlayerDataHandler.playerDataInstance.vfxDeath, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }



}

