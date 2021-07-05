using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerHealth : MonoBehaviour
{
    [SerializeField] int enemyLayer;

    [SerializeField] GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            //LLamar GameManager
            Instantiate(explosion, transform.position, Quaternion.identity);
            // SoundFXManager.soundFXManagerInstance.PlaySound(1);
            Destroy(gameObject);
        }
    }

}
