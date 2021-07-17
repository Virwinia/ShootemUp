
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // The Player dies if collides agaisnt an enemy or a meteorite, dies
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
        AudioManager.audioManagerInstance.PlaySound(0);
        Instantiate(GetComponent<PlayerDataHandler>().vfxDeath, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }



}

