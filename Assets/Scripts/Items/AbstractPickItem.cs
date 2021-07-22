
using UnityEngine;

public abstract class AbstractPickItem : MonoBehaviour
{
    public ItemSO itemData;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 gravity;
    Vector2 spawnPosition;

    private void Awake()
    {
        rb.velocity = gravity;
        spawnPosition = this.gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_PLAYER) || (collision.gameObject.tag == StaticValues.TAG_SHIELD))
        {
            DoSomething();
            if (PowerUpIsPickable())
                ItemDeath();
        }
    }

    void ItemDeath()
    {
        Destroy(gameObject);
    }

    public abstract void DoSomething();
    public abstract bool PowerUpIsPickable();

}
