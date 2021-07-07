using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager ObjectPoolInstance = null;

    [SerializeField] GameObject objectToPool;
    [SerializeField] int objectPoolAmount;
    GameObject[] pooledObjects;
    int activeIndex = 0;

    // [Space]
    // [Header("NPCs ---")]
    // [SerializeField] GameObject[] npcToPool;
    // [SerializeField] int npcPoolAmount;
    // GameObject[] pooledNPCs;

    // TO DO --------
    // [Space]
    // [Header("Loots ---")]
    // [SerializeField] GameObject lootPool;
    // [SerializeField] int lootPoolAmount;
    // GameObject[] pooledLoot;


    private void Awake()
    {
        if (ObjectPoolInstance == null) ObjectPoolInstance = this;
        else if (ObjectPoolInstance != this) Destroy(gameObject);
    }

    private void Start()
    {
        pooledObjects = new GameObject[objectPoolAmount];

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
