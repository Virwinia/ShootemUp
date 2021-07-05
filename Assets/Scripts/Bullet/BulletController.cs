using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 bulletVelocity;
    [SerializeField] int damage;
    GameObject bullet;

    void Start()
    {
        rb.velocity = bulletVelocity;
        bullet = ObjectPool.ObjectPoolInstance.GetPooledObject();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //USAR IDAMAGEABLE PARA AÑADIR OTROS ELEMENTOS QUE PUEDAN DAÑARSE - ASTEROIDES
        // ESTO PODRÍA DAR PROBLEMAS -- ENMIGOS DAÑANDO ENEMIGOS
        // PODRIA SOLUCIONARSE SI TUVIESE BULLETCONTROLLER Y ENEMYBULLETCONTROLLER?
        //if(other.gameObject.GetComponent<IDamageable>()!=null){ 
        //other.gameObject.GetComponent<IDamageable>().TakeDamage(damage);
        //}

        if (other.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_ENEMY) ||
       other.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_ROCK))
        {
            other.gameObject.GetComponent<EnemyHealth>().RemoveHP(damage, transform.position);
            bullet.SetActive(false);
        }

    }

}

