
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

    public void CreateEnemyProjectile()
    {
        GameObject enmBullet = ObjectPoolManager.ObjectPoolInstance.GetEnemyPooledObject();
        if (enmBullet != null)
        {
            enmBullet.transform.position = gameObject.transform.position;
            enmBullet.transform.rotation = gameObject.transform.rotation;
            enmBullet.SetActive(true);
        }
    }

}
