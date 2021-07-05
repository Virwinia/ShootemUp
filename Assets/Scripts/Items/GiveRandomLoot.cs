/* 
    Looter---
    When the object dies, it gives a coin but there is a chance to loot powerups.
    If the designer doesn't write any value in Inspector for chances, the system will calculate chances based on a bezier.
*/

using UnityEngine;

public class GiveRandomLoot : MonoBehaviour
{
    [Header("Looter ---")]
    [Tooltip("How many options has the player to get a powerup instead a coin.")]
    [Range(0, 1)] [SerializeField] float chanceToLootPowerUp;

    [Space]
    [Header("Reward Coin ---")]
    [Tooltip("Coins to loot.")]
    [SerializeField] CoinSO[] coins;
    [Tooltip("The randomness will take values from a curve.")]
    [SerializeField] AnimationCurve bezierValue;

    public void CalculateLootingChances()
    {
        float dice = Random.value;  // roll a dice to know if the player gets something

        if (dice <= chanceToLootPowerUp)
        {
            //GET POWER UP
            print("power up");
        }
        else
        {
            GetCoin();
        }
    }

    // void GetPowerUp()
    // {
    // }

    void GetCoin()
    {
        if (coins.Length == 0) return;

        float curveRandomness = bezierValue.Evaluate(Random.value) * 100;    // To give weight, we take a random a value from a curve.
        int nChance = (int)(100 / coins.Length);    // Distribute the weight between the items in the array.

        for (int i = 0; i <= coins.Length; i++)
        {
            if (curveRandomness > nChance * (i - 1) && curveRandomness <= nChance * i)
                CreateCoin(coins[i - 1]);
        }
    }

    void CreateCoin(CoinSO obj)
    {
        if (obj != null) Instantiate(obj.coinPrefab, this.transform.position, Quaternion.identity);
        else return;
    }

}
