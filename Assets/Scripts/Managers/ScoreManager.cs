using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;

    [SerializeField] int score, scoreRecord;

    [Space]
    [Header("UI ---")]
    [SerializeField] Text scoreText;
    [SerializeField] Text scoreRecordText;

    private void Awake()
    {
        scoreManager = this;
    }

    private void Start()
    {
        scoreRecordText.text = "Record: " + PlayerPrefs.GetInt("Record").ToString();
    }
    public void AddScore(int n)
    {
        score += n;
        scoreText.text = "Score: " + score.ToString();
    }
    public void CheckRecord()
    {
        if (score > scoreRecord)
        {
            PlayerPrefs.SetInt("Record", score);
        }

    }
}
