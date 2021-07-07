
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    public void CreateProjectile()
    {
        GameObject bullet = ObjectPoolManager.ObjectPoolInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = gameObject.transform.position;
            bullet.transform.rotation = gameObject.transform.rotation;
            bullet.SetActive(true);
        }
    }

}
