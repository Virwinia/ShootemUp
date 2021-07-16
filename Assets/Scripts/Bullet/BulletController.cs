
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
        if (other.gameObject.CompareTag(StaticValues.TAG_PLAYER))
        {
            other.gameObject.GetComponent<PlayerHealth>().PlayerDeath();
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.GetComponent<IDamageable>() != null
        && this.gameObject.CompareTag(StaticValues.TAG_PLAYER))
        {
            print("BULLET");
            other.gameObject.GetComponent<IDamageable>().TakeDamage(damage, transform.position.x, transform.position.y);
            this.gameObject.SetActive(false);
        }
    }

}

