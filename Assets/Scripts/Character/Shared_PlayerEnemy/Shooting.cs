
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    public void CreateProjectile()
    {
        GameObject bullet = ObjectPoolManager.ObjectPoolInstance.GetPooledObject();
        if (bullet != null)
            ProjectileCreation(bullet);
    }

    public void CreateEnemyProjectile()
    {
        GameObject enmBullet = ObjectPoolManager.ObjectPoolInstance.GetEnemyPooledObject();
        if (enmBullet != null)
            ProjectileCreation(enmBullet);
    }

    void ProjectileCreation(GameObject obj)
    {
        obj.transform.position = gameObject.transform.position;
        obj.transform.rotation = gameObject.transform.rotation;
        obj.SetActive(true);
        AudioManager.audioManagerInstance.PlaySound(1);
    }

}
