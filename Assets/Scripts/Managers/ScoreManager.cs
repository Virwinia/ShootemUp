using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;

    [Space]
    [Header("Player Score ---")]
    [SerializeField] ScoreSaveData ScoreData;               // This class contains the score data.
    [ReadOnly] [SerializeField] int playerScore;
    [Space]
    [SerializeField] MenuInGame menuInGame;
    [SerializeField] MenuGameOver menuGameOver;

    PlayerDataHandler playerData;

    //DEPRECATED -- [Tooltip("Text shows in game, on top left side of the screen.")]
    //DEPRECATED --  [SerializeField] Text txtScoreRecordIG, txtMyScoreIG;   // Text in game
    //DEPRECATED --  [Tooltip("Text shows on Game Over screen, in the middle of the screen.")]
    //DEPRECATED --  [SerializeField] Text txtRecordTitleGO, txtMyScoreGO;   // Text on screen game over

    private void Awake()
    {
        scoreManager = this;
    }

    private void Start()
    {
        playerData = GameManager.gameManagerInstance.playerData;
        playerScore = playerData.score;

        LoadDataFromPlayerPrefs();

        menuInGame.MyScore(playerScore);
        menuInGame.Record(ScoreData.scoreMax);

        //DEPRECATED -- txtScoreRecordIG.text = "Record: " + ScoreData.scoreMax;
        //DEPRECATED -- txtMyScoreIG.text = "Score: " + playerScore.ToString();
        //DEPRECATED -- txtMyScoreIG.color = new Color32(234, 58, 109, 160);
    }

    public void ShowRecordInGameOverScreen()
    {
        if (playerScore > ScoreData.scoreMax)
        {
            // DEPRECATED --txtRecordTitleGO.text = "You beated the record!";
            // DEPRECATED --txtMyScoreGO.text = playerScore.ToString();
            menuGameOver.RecordWasBeaten(true);
            menuGameOver.maxScore.text = playerScore.ToString();
        }
        else
        {
            // DEPRECATED --txtRecordTitleGO.text = "Yet, unbeatable...";
            // DEPRECATED --txtMyScoreGO.text = ScoreData.scoreMax.ToString();
            menuGameOver.RecordWasBeaten(false);
            menuGameOver.maxScore.text = ScoreData.scoreMax.ToString();
        }
    }

    public void AddScore(int n)
    {
        playerScore += n;

        menuInGame.MyScore(playerScore);
        if (playerScore > ScoreData.scoreMax) menuInGame.MyScoreBreaksTheRecord();

        //DEPRECATED -- txtMyScoreIG.text = "Score: " + playerScore.ToString();
        //DEPRECATED -- txtMyScoreIG.color = new Color32(90, 248, 218, 160);
    }


    // SAVE/LOAD DATA - Checker ----
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
        {
            ScoreData = new ScoreSaveData();    // create new data,
            playerScore = 0;                    // setting the inital player score...
            ScoreData.scoreMax = 0;             // ... and max score to zero,
        }
        else                                    // else, you can use the data from playerPrefabs file.
        {
            string jsonDataScoreMax = PlayerPrefs.GetString(StaticValues.SCOREDATA_KEY);
            ScoreData = JsonUtility.FromJson<ScoreSaveData>(jsonDataScoreMax);
            Debug.Log("Load MaxScore Saved HAS NEW DATA: " + jsonDataScoreMax);
        }
    }

    // SAVE DATA
    public void SaveDataInPlayerPrefs()         //---> THIS MUST BE CALLED WHEN GAME IS OVER
    {
        if (playerScore > ScoreData.scoreMax)   // If current Player's score is higher than records,
            ScoreData.scoreMax = playerScore;   // save that info.

        string jsonDataScoreMax = JsonUtility.ToJson(ScoreData, true);
        PlayerPrefs.SetString(StaticValues.SCOREDATA_KEY, jsonDataScoreMax);
        Debug.Log("Your score is " + playerScore + " and MaxScore HAS NEW DATA: " + jsonDataScoreMax);
    }
    // ---------------------------


}
