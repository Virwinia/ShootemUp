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
    [SerializeField] GameObject[] prefabEnemy;

    [Space] [SerializeField] float timeBetweenSpawns;
    [SerializeField] int spawnedEnemiesMax;
    [HideInInspector] public bool isSpawnActive;
    int spawnedEnemies;

    private void OnEnable()
    {
        InvokeRepeating("CreateEnemy", 0, timeBetweenSpawns);
    }

    void CreateEnemy()
    {
        if (gameObject.activeInHierarchy)
        {
            if (isSpawnActive)
            {
                GameObject enemy = Instantiate(prefabEnemy[Random.Range(0, prefabEnemy.Length)], transform.position, Quaternion.identity);
                enemy.transform.SetParent(this.gameObject.transform);   // To avoid have lot of gameobjects in Hierarchy, move into a go as children.
                                                                        //NOTA--> ASIGNAR PATH A ENEMIGO
                spawnedEnemies++;


                if (spawnedEnemies >= spawnedEnemiesMax)
                {
                    isSpawnActive = false;
                    spawnedEnemies = 0;
                    // this.gameObject.SetActive(false);
                    SpawnManager.spawnManager.ActivateSpawner();
                }

            }
        }
    }

    public void ActiveSpawner()
    {
        isSpawnActive = true;
    }
}
