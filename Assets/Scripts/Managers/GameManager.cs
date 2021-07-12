using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance = null;

    [Space]
    [Header("UI ----")]
    [SerializeField] GameObject gameOverScreen; //FUTRE -- TODO in another script -script UI

    [Space]
    [Header("Player Data ----")]
    public PlayerSO playerSO;

    [Space]
    [Header("Scene and enemies ----")]
    [SerializeField] GameObject despawnObject;

    int playerHealth;
    float respawnTime = 1;
    Vector2 respawnPosition = new Vector2(0.0f, -2f);
    PlayerDataHandler playerData;
    GameObject player;

    private void Awake()
    {
        if (gameManagerInstance == null) gameManagerInstance = this;
        else if (gameManagerInstance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);  // By adding this line, Singleton is a Manager,it persists between different scenes. 
    }

    private void Start()
    {
        SetPlayerData(true);
    }

    void SetPlayerData(bool isNewGame)
    {
        GameObject obj = GameObject.FindGameObjectWithTag(StaticValues.TAG_PLAYER);
        AudioManager.audioManagerInstance.audioSource = obj.GetComponent<AudioSource>();

        playerData = obj.GetComponent<PlayerDataHandler>(); // Before starting the game, values are set according the given data in PlayerSO.
        if (isNewGame) playerHealth = playerData.health;    // Then, values (health) will change according in-game player progression.
        player = playerData.player;
    }

    public void RemovePlayerHealth()
    {
        playerHealth--;
        if (playerHealth <= 0)
        {
            if (gameOverScreen != null)
                gameOverScreen.SetActive(true);

            ScoreManager.scoreManager.SaveDataInPlayerPrefs();
            EnemySpawnerIsActive(false);
        }
        else
        {
            StartCoroutine(GenerateNewShip());
        }
    }

    IEnumerator GenerateNewShip()
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(playerSO.Player, respawnPosition, Quaternion.identity);
        SetPlayerData(false);
        EnemySpawnerIsActive(true);
    }

    void EnemySpawnerIsActive(bool isActive)
    {
        despawnObject.SetActive(isActive);
    }




}

