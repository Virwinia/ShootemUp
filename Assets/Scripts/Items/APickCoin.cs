using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APickCoin : AbstractPickItem
{
    [Space] [ReadOnly] [SerializeField] int score;

    private void Start()
    {
        score = itemData.score;
    }

    public override void DoSomething()
    {
        ScoreManager.scoreManager.AddScore(score);
        AudioManager.audioManagerInstance.PlaySound(3);
    }

}
