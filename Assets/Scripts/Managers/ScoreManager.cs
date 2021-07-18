using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;

    [Space]
    [Header("Player Score ---")]
    [SerializeField] ScoreSaveData ScoreData;    // This class contains the score data.
    [ReadOnly] [SerializeField] int playerScore;
    PlayerDataHandler playerData;
    [Tooltip("Text shows in game, on top left side of the screen.")]
    [SerializeField] Text txtScoreRecordIG, txtMyScoreIG;      // Text in game
    [Tooltip("Text shows on Game Over screen, in the middle of the screen.")]
    [SerializeField] Text txtRecordTitle, txtScoreGO;  // Text on screen game over

    private void Awake()
    {
        scoreManager = this;
    }

    private void Start()
    {
        playerData = GameManager.gameManagerInstance.playerData;
        playerScore = playerData.score;

        LoadDataFromPlayerPrefs();

        txtScoreRecordIG.text = "Record: " + ScoreData.scoreMax;
        txtMyScoreIG.color = new Color32(234, 58, 109, 200);
        txtMyScoreIG.text = "Score: " + playerScore.ToString();
    }

    public void ShowRecordInGameOverScreen()
    {
        if (playerScore > ScoreData.scoreMax)
        {
            txtRecordTitle.text = "New Record!";
            txtScoreGO.text = playerScore.ToString();
        }
        else
        {
            txtRecordTitle.text = "Yet, unbeatable...";
            txtScoreGO.text = ScoreData.scoreMax.ToString();
        }
    }

    public void AddScore(int n) //---> FUTURE ME: pasar a interfaz??
    {
        playerScore += n;
        txtMyScoreIG.text = "Score: " + playerScore.ToString();
        if (playerScore > ScoreData.scoreMax)
            txtMyScoreIG.color = new Color32(90, 248, 218, 200);
    }

    //------------------
    // SAVE/LOAD DATA - Checker
    public bool PlayerHasDataSaved()
    {
        bool hasData = PlayerPrefs.HasKey(StaticValues.SCOREDATA_KEY);   // This key is unique and CAN'T BE CHANGED, or all the saved data will lose.
                                                                         // I can create other keys to save different data:
                                                                         // ShootemUp_PlayerData, ShootemUp_WorldData... etc
        return hasData;
    }

    // LOAD DATA
    public void LoadDataFromPlayerPrefs()
    {
        if (!PlayerHasDataSaved())              // If there is not some saved data...
            ScoreData = new ScoreSaveData();    // create new data,
        else                                    // else, you can use the saved ones.
        {
            string jsonDataScoreMax = PlayerPrefs.GetString(StaticValues.SCOREDATA_KEY);
            ScoreData = JsonUtility.FromJson<ScoreSaveData>(jsonDataScoreMax);
            Debug.Log("Load MaxScore Saved HAS NEW DATA: " + jsonDataScoreMax);
        }
    }

    // SAVE DATA
    public void SaveDataInPlayerPrefs() //---> THIS MUST BE CALLED WHEN GAME IS OVER
    {
        if (playerScore > ScoreData.scoreMax)     // If current Player's score is higher than records,
            ScoreData.scoreMax = playerScore;    // save that info.

        string jsonDataScoreMax = JsonUtility.ToJson(ScoreData, true);
        PlayerPrefs.SetString(StaticValues.SCOREDATA_KEY, jsonDataScoreMax);
        Debug.Log("Your score is " + playerScore + " and MaxScore HAS NEW DATA: " + jsonDataScoreMax);
    }
    //------------------


}
