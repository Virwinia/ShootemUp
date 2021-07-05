using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawnManager;
    [SerializeField] EnemySpawner[] spawners;
    [SerializeField] float timeBetweenWave, timeFirstWave;

    private void Awake()
    {
        spawnManager = this;

        spawners = GetComponentsInChildren<EnemySpawner>();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(timeFirstWave);
        ActivateSpawner();
    }

    public void ActivateSpawner()
    {
        StartCoroutine(ActivateSpawnerCoroutine());
    }

    IEnumerator ActivateSpawnerCoroutine()
    {
        yield return new WaitForSeconds(timeBetweenWave);
        int temp = Random.Range(0, spawners.Length);
        spawners[temp].gameObject.SetActive(true);
    }
}
