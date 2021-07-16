
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager ObjectPoolInstance;

    [Space]
    [Header("Player Projectile ---")]
    [SerializeField] GameObject objectToPool;
    [SerializeField] int objectPoolAmount;
    GameObject[] pooledObjects;
    int activeIndex = 0;

    [Space]
    [Header("Enemy Projectile ---")]
    [SerializeField] GameObject enmObjectToPool;
    [SerializeField] int enmObjectPoolAmount;
    GameObject[] enmPooledObjects;
    int enmActiveIndex = 0;

    private void Awake()
    {
        ObjectPoolInstance = this;
    }

    private void Start()
    {
        pooledObjects = new GameObject[objectPoolAmount];
        enmPooledObjects = new GameObject[enmObjectPoolAmount];

        for (int i = 0; i < pooledObjects.Length; i++)  //Create the pool instantiating the objectToPool the specified number of times in amountToPool. 
        {
            pooledObjects[i] = Instantiate(objectToPool);
            pooledObjects[i].transform.SetParent(this.gameObject.transform);
            pooledObjects[i].SetActive(false);
        }

        for (int i = 0; i < enmPooledObjects.Length; i++)
        {
            enmPooledObjects[i] = Instantiate(enmObjectToPool);
            enmPooledObjects[i].transform.SetParent(this.gameObject.transform);
            enmPooledObjects[i].SetActive(false);
        }
    }

    public GameObject GetPooledObject()
    {
        activeIndex++;
        if (activeIndex >= pooledObjects.Length)
            activeIndex = 0;
        return pooledObjects[activeIndex];
    }

    public GameObject GetEnemyPooledObject()
    {
        enmActiveIndex++;
        if (enmActiveIndex >= enmPooledObjects.Length)
            enmActiveIndex = 0;
        return enmPooledObjects[enmActiveIndex];
    }
}
