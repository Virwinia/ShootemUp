
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
        AudioManager.audioManagerInstance.PlaySound(6);
    }

    public override bool PowerUpIsPickable()
    {
        if (itemData.id < 20) return true;
        else return false;
    }


}
