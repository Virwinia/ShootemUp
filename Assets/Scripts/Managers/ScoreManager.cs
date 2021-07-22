
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;

    [Space]
    [Header("Player Score ---")]
    [SerializeField] ScoreSaveData ScoreData;               // This class contains the score data.
    [ReadOnly] [SerializeField] int playerScore;
    [Space] [SerializeField] MenuInGame menuInGame;
    [SerializeField] MenuGameOver menuGameOver;
    PlayerDataHandler playerData;

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
    }

    public void ShowRecordInGameOverScreen()
    {
        if (playerScore > ScoreData.scoreMax)
        {
            menuGameOver.RecordWasBeaten(true);
            menuGameOver.maxScore.text = playerScore.ToString();
        }
        else
        {
            menuGameOver.RecordWasBeaten(false);
            menuGameOver.maxScore.text = ScoreData.scoreMax.ToString();
        }
    }

    public void AddScore(int n)
    {
        playerScore += n;

        menuInGame.MyScore(playerScore);
        if (playerScore > ScoreData.scoreMax) menuInGame.MyScoreBreaksTheRecord();
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
