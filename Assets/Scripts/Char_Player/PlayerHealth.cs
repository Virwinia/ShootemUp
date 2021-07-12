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
            GameManager.gameManagerInstance.RemovePlayerHealth();

            AudioManager.audioManagerInstance.PlaySound(0);

            GameObject playerDeath = GetComponent<PlayerDataHandler>().vfxDeath;
            Instantiate(playerDeath, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
