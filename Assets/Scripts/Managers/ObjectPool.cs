using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool ObjectPoolInstance;

    [SerializeField] GameObject objectToPool;
    [SerializeField] int amountToPool;
    [SerializeField] GameObject[] pooledObjects;
    int activeIndex = 0;

    private void Awake()
    {
        ObjectPoolInstance = this;
    }

    private void Start()
    {
        pooledObjects = new GameObject[amountToPool];

        for (int i = 0; i < pooledObjects.Length; i++)  //Create the pool instantiating the objectToPool the specified number of times in amountToPool. 
        {
            pooledObjects[i] = Instantiate(objectToPool);
            pooledObjects[i].transform.SetParent(this.gameObject.transform);
            pooledObjects[i].SetActive(false);
        }
    }

    public GameObject GetPooledObject()
    {
        activeIndex++;
        if (activeIndex >= pooledObjects.Length)
            activeIndex = 0;
        return pooledObjects[activeIndex];
    }
}
