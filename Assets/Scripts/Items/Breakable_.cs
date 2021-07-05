/*
Breakable---
When the player hits the object, it takes damage.
If the object breaks, it dies.

*/

using UnityEngine;

public class Breakable_ : MonoBehaviour, IDamageable
{
    [SerializeField] int health = 1;


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            BreakableDeath();
            // GiveRandomLoot_ giveLoot = GetComponent<GiveRandomLoot_>();
            // giveLoot.CalculateChanceToGetLoot();
        }
    }

    void BreakableDeath()
    {
        Destroy(gameObject, 0.1f);
    }




}
