
using UnityEngine;

public class BoundaryKiller : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            other.gameObject.SetActive(false);
        }
        else if (!other.gameObject.CompareTag(StaticValues.TAG_BACKGROUND))
        {
            Destroy(other.gameObject);  // Destroy anything quitting the boundaries.

            // Recalculate enemies in spawnManager's counter
            if (other.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_ENEMY)
            || other.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_ROCK))
                SpawnManager.spawnManager.RemoveEnemyFromCounter();
        }

    }
}