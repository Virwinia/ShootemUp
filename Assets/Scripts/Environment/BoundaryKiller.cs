/*
** IMPORTANT ** Note for future projects **

Any script holding the method OnTriggerExit, if it has to destroy something,
it is better to SAY EXACTLY what has to destroy. DON'T use generic instructions as:

    if(!other.Player)
    Destroy();

Because it will kill EVERYTHING, even SetActive(false) or enable=false.
*/

using UnityEngine;

public class BoundaryKiller : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_BULLET))
            other.gameObject.SetActive(false);

        if (other.gameObject.CompareTag(StaticValues.TAG_PICKABLE))
            Destroy(other.gameObject);

        if (other.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_ENEMY)
        || other.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_ROCK))
        {
            Destroy(other.gameObject);
            SpawnManager.spawnManager.RemoveEnemyFromCounter(); // Recalculate enemies in spawnManager's counter.
        }
    }
}