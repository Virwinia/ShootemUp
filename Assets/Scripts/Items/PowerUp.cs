using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 powerUpVelocity;

    void Start()
    {
        rb.velocity = powerUpVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_PLAYER))
        {
            // DO SOMETHING
            PowerUpDeath();
        }
    }

    void PowerUpDeath()
    {
        //MUsic
        //Particle
        Destroy(gameObject);

    }
}
