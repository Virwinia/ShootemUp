using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance = null;

    [Space]
    [ReadOnly] public PlayerDataHandler playerData;
    [SerializeField] GameObject gameOverScreen; //FUTRE -- TODO in another script -script UI
    // [SerializeField] GameObject spawnManager;

    int playerHealth;
    float respawnTime = 1;
    Vector2 respawnPosition = new Vector2(0.0f, -2f);
    GameObject player;

    private void Awake()
    {
        if (gameManagerInstance == null) gameManagerInstance = this;
        else if (gameManagerInstance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);  // By adding this line, Singleton is a Manager,it persists between different scenes. 

        SetPlayerData(true);
    }

    void SetPlayerData(bool isNewGame)
    {
        GameObject obj = GameObject.FindGameObjectWithTag(StaticValues.TAG_PLAYER);
        AudioManager.audioManagerInstance.audioSource = obj.GetComponent<AudioSource>();

        playerData = obj.GetComponent<PlayerDataHandler>(); // Before starting the game, values are set according the given data in PlayerSO.
        player = playerData.objPlayer;

        if (isNewGame) playerHealth = playerData.health;    // Set starting values.
    }

    public void RemovePlayerHealth()
    {
        playerHealth--;
        if (playerHealth <= 0)
        {
            if (gameOverScreen != null) gameOverScreen.SetActive(true);
            ScoreManager.scoreManager.SaveDataInPlayerPrefs();

            // SpawnManager.spawnManager.gameObject.SetActive(false);
        }
        else { StartCoroutine(GenerateNewShip()); }
    }

    IEnumerator GenerateNewShip()
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(playerData.objPlayer, respawnPosition, Quaternion.identity);
        SetPlayerData(false);

        // SpawnManager.spawnManager.gameObject.SetActive(true);



    }



}

