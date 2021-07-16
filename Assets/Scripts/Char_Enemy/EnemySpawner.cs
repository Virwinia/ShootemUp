// NOTA: A DESARROLLAR A FUTURO - ---
//  Enemy spawner should know 
// - wave time 
// - max enemies to spawn
// - paths tp follow --> mejor que lo tenga manager, para evitar repetir
// Manager shoudl know max enemies in scene and limit spawner if needed

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Space] [SerializeField] GameObject[] prefabEnemy;
    [Space] [SerializeField] float spawnTime = 2;
    public int enemiesPerSpawn = 3;
    public int spawnedEnemies;
    bool canSpawn;

    public void SpawningProcess()
    {
        InvokeRepeating("CreateEnemy", 0, spawnTime);
    }

    public void CancelSpawningProcess()
    {
        CancelInvoke();
    }

    void CreateEnemy()
    {
        if (SpawnManager.spawnManager.CanSpawn())
        {
            GameObject enemy = Instantiate(prefabEnemy[Random.Range(0, prefabEnemy.Length)], transform.position, Quaternion.identity);
            enemy.transform.SetParent(this.gameObject.transform);   // To avoid have lot of gameobjects in Hierarchy, move into a go as children.
                                                                    //NOTA--> ASIGNAR PATH A ENEMIGO
            spawnedEnemies++;
            SpawnManager.spawnManager.AddEnemyToCounter();

            if (spawnedEnemies == enemiesPerSpawn)
            {
                CancelInvoke();
                spawnedEnemies = 0;
                SpawnManager.spawnManager.ActivateNextSpawner();
            }
        }
    }
}
