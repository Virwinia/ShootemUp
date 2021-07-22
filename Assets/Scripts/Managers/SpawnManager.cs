using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawnManager;

    public EnemySpawner[] spawners;
    [SerializeField] float timeFirstWave, timeBetweenWave;
    [SerializeField] int enemiesPerWave = 5;

    int enemiesInScene = 0;
    int enemyCapacity;
    bool canSpawn;

    private void Awake()
    {
        spawnManager = this;
        spawners = GetComponentsInChildren<EnemySpawner>();
        if (spawners.Length == 0) Debug.Log("Array lenght is zero in gameobject " + gameObject.name);

        enemyCapacity = enemiesPerWave;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(timeFirstWave);
        StartCoroutine(ActivateSpawnerCoroutine());
    }

    IEnumerator ActivateSpawnerCoroutine()                      // Starting the game, 
    {
        yield return new WaitForSeconds(timeBetweenWave);

        int activeSpawner = Random.Range(0, spawners.Length);   // manager chooses which spawner will work
        spawners[activeSpawner].SpawningProcess();              // ...start spawning

    }

    public void ActivateNextSpawner()
    {
        StartCoroutine(ActivateSpawnerCoroutine());
    }

    public void AddEnemyToCounter()
    {
        enemiesInScene++;
    }

    public void RemoveEnemyFromCounter()
    {
        enemiesInScene--;
    }

    public bool CanSpawn()
    {
        enemyCapacity = enemiesPerWave - enemiesInScene;

        canSpawn = enemyCapacity > 0 ? true : false;
        return canSpawn;
    }

}
