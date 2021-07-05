using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int playerHealth;
    [SerializeField] GameObject gameOverScreen, winScreen;
    [SerializeField] float respawnTime;
    [SerializeField] GameObject playerShip;
    [SerializeField] Vector2 respawnPosition;

    private void Awake()
    {
        gameManager = this;
    }
    public void RemovePlayerHealth()
    {
        playerHealth--;
        if (playerHealth <= 0)
        {
            gameOverScreen.SetActive(true);
            ScoreManager.scoreManager.CheckRecord();
        }
        else
        {
            StartCoroutine(GenerateNewShip());
        }
    }

    IEnumerator GenerateNewShip()
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(playerShip, respawnPosition, Quaternion.identity);
    }
}

