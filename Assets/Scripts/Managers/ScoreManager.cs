using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;

    [Space]
    [Header("Player Score ---")]
    [ReadOnly] [SerializeField] int playerScore;
    [SerializeField] ScoreSaveData scoreSaveData;


    [Space]
    [Header("UI ---")]
    [SerializeField] Text scoreText;
    [SerializeField] Text scoreRecordText;

    private void Awake()
    {
        scoreManager = this;
        playerScore = GameManager.gameManagerInstance.playerSO.score;
    }

    private void Start()
    {
        LoadDataFromPlayerPrefs();
        scoreRecordText.text = "Record: " + playerScore;
    }

    public void AddScore(int n)
    {
        playerScore += n;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    // SAVE/LOAD DATA - GameManager needs to read PlayerPrefs
    public bool PlayerHasDataSaved()
    {

        bool hasData = PlayerPrefs.HasKey(StaticValues.SCOREDATA_KEY);   // This key is unique and CAN'T BE CHANGED, or all the saved data will lose.
                                                                         // I can create other keys to save different data:
                                                                         // ShootemUp_PlayerData, ShootemUp_WorldData... etc

        return hasData;

    }

    public void LoadDataFromPlayerPrefs()
    {
        if (!PlayerHasDataSaved())                  // If there is not some saved data...
            scoreSaveData = new ScoreSaveData();    // create new data,
        else                                        // else, you can use the saved ones.
        {
            string jsonDataScoreMax = PlayerPrefs.GetString(StaticValues.SCOREDATA_KEY);
            scoreSaveData = JsonUtility.FromJson<ScoreSaveData>(jsonDataScoreMax);
            Debug.Log("LoadPlayerScoreRecord HAS NEW DATA: " + jsonDataScoreMax);
            LoadPlayerScoreRecord();                // Load ScoreMax data.
        }
    }

    public void SaveDataInPlayerPrefs() //---> THIS MUST BE CALLED WHEN GAME IS OVER
    {
        SavePlayerScoreRecord();
        string jsonDataScoreMax = JsonUtility.ToJson(scoreSaveData, true);
        PlayerPrefs.SetString(StaticValues.SCOREDATA_KEY, jsonDataScoreMax);
    }

    void LoadPlayerScoreRecord()   // SaveData updates according to the local values (Save)
    {
        playerScore = scoreSaveData.scoreMax;
    }

    void SavePlayerScoreRecord()
    {
        if (playerScore > scoreSaveData.scoreMax)     // If current Player's score is higher than records,
            scoreSaveData.scoreMax = playerScore;    // save that info.
    }

}
