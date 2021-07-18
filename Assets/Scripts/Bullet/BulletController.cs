
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 bulletVelocity;
    [SerializeField] int damage;
    public bool isPlayer;
    // float startingPOsition;
    // float newPosition;

    void Start()
    {
        if (this.gameObject.tag == StaticValues.TAG_PLAYER)
            isPlayer = true;

        // startingPOsition = gameObject.transform.position.y;
        // newPosition = startingPOsition;
    }

    private void OnEnable()
    {
        rb.velocity = bulletVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isPlayer)
        {
            // Bullet gameobject desactivates...
            // ... when hits a IDamageable (enemies)
            if (other.gameObject.GetComponent<IDamageable>() != null)
            {
                other.gameObject.GetComponent<IDamageable>().TakeDamage(damage, transform.position.x, transform.position.y);
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            // ... when hits the Player 
            if (other.gameObject.CompareTag(StaticValues.TAG_PLAYER))
            {
                other.gameObject.GetComponent<PlayerHealth>().PlayerDeath();
                this.gameObject.SetActive(false);
            }

            // ... when hits the Shield, if the bullet is fired by an enemy
            if (other.gameObject.CompareTag(StaticValues.TAG_SHIELD))
            {
                this.gameObject.SetActive(false);
                PlayerDataHandler.playerDataInstance.ShieldActivation(false);
            }
        }


    }




    // public delegate void ShieldStatusDelegate();        // Declaration.
    // public event ShieldStatusDelegate ShieldActivation; // Event --> what happens when the event triggers is in ShieldBehaviour.
    // public void ShieldActivationMethod()                // Call to ShieldBehavior to do something there.
    // {
    //     if (ShieldActivation != null)
    //         ShieldActivation();
    // }

}

