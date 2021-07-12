
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
        bullet = ObjectPoolManager.ObjectPoolInstance.GetPooledObject();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<IDamageable>() != null)
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(damage, transform.position.x, transform.position.y);
            // other.gameObject.GetComponent<EnemyHealth>().PositionEffectsInHit(transform.position);
            this.gameObject.SetActive(false);
        }
    }

}

