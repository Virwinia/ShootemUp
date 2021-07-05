using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject prefabEnemy;

    [Space] [SerializeField] float spawnTime;
    [SerializeField] int maxEnemiesPerWave;
    int spawnedEnemies;

    private void OnEnable()
    {
        InvokeRepeating("CreateEnemy", 0, spawnTime);
    }

    void CreateEnemy()
    {
        if (gameObject.activeInHierarchy)
        {
            Instantiate(prefabEnemy, transform.position, Quaternion.identity);
            spawnedEnemies++;

            //NOTA--> ASIGNAR PATH A ENEMIGO

            if (spawnedEnemies >= maxEnemiesPerWave)
            {
                spawnedEnemies = 0;
                this.gameObject.SetActive(false);
                SpawnManager.spawnManager.ActivateSpawner();
            }
        }
    }
}
