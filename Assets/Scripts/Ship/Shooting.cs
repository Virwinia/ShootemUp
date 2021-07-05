
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    public void CreateProjectile()
    {
        GameObject bullet = ObjectPool.ObjectPoolInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = gameObject.transform.position;
            bullet.transform.rotation = gameObject.transform.rotation;
            bullet.SetActive(true);
        }
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

}
