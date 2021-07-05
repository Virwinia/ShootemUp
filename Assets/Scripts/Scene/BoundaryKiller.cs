
using UnityEngine;

public class BoundaryKiller : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            other.gameObject.SetActive(false);
        }
        else Destroy(other.gameObject);


    }
}