using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_ENEMY) ||
       collision.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_ROCK))
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        // GameManager reduces playerHealth
        GameManager.gameManagerInstance.RemovePlayerHealth();
        // Plays sound and particles for PlayerDeath
        AudioManager.audioManagerInstance.PlaySound(0);
        Instantiate(GetComponent<PlayerDataHandler>().vfxDeath, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

}

