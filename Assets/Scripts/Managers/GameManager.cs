using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance = null;

    [Space]
    [ReadOnly] public PlayerDataHandler playerData;
    [SerializeField] GameObject gameOverScreen; //FUTRE -- TODO in another script -script UI

    public int playerHealth;
    float respawnTime = 1;
    Vector2 respawnPosition = new Vector2(0.0f, -2f);
    GameObject playerPrefab;

    private void Awake()
    {
        if (gameManagerInstance == null) gameManagerInstance = this;
        else if (gameManagerInstance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);  // By adding this line, Singleton is a Manager,it persists between different scenes. 
    }

    private void Start()
    {
        if (gameOverScreen.activeInHierarchy) gameOverScreen.SetActive(false);
        SetPlayerData(true);
    }

    void SetPlayerData(bool isNewGame)
    {
        playerData = PlayerDataHandler.playerDataInstance; // Before starting the game, values are set according the given data in PlayerSO.
        AudioManager.audioManagerInstance.audioSource = playerData.gameObject.GetComponent<AudioSource>();
        playerPrefab = playerData.objPlayer;
        if (isNewGame) playerHealth = playerData.health;    // Set starting values.
    }

    public void RemovePlayerHealth()
    {
        playerHealth--;
        if (playerHealth <= 0)
        {
            if (gameOverScreen != null) gameOverScreen.SetActive(true);
            ScoreManager.scoreManager.ShowRecordInGameOverScreen();
            ScoreManager.scoreManager.SaveDataInPlayerPrefs();
        }
        else { StartCoroutine(GenerateNewShip()); }
    }

    IEnumerator GenerateNewShip()
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(playerPrefab, respawnPosition, Quaternion.identity);
        SetPlayerData(false);
    }
}

