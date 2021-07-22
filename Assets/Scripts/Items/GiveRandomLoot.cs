/* 
    Looter---
    When the object dies, it gives a coin but there is a chance to loot powerups.
    If the designer doesn't write any value in Inspector for chances, the system will calculate chances based on a bezier.
*/

using UnityEngine;

public class GiveRandomLoot : MonoBehaviour
{

    [Space]
    [Header("Reward Coin ---")]
    [Tooltip("Coins to loot.")]
    [Range(0, 1)] [SerializeField] float chanceToGetReward;
    [SerializeField] ItemSO[] coins;
    [Tooltip("The randomness will take values from a curve.")]
    [SerializeField] AnimationCurve bezierValue;

    [Space]
    [Header("Looter ---")]
    [Tooltip("How many options has the player to get a powerup instead a coin.")]
    [Range(0, 1)] [SerializeField] float chanceToLootPowerUp;
    [SerializeField] ItemSO[] powerUps;
    float curveRandomness;

    private void Start()
    {
        if (coins.Length == 0) Debug.LogWarning("<b><color=blue>Items array is empty</color></b> in " + gameObject.name);
    }

    public void CalculateLootingChances()
    {
        float dice = Random.value;      // Roll a dice to know if the player gets something.
        if (dice <= chanceToGetReward)
        {
            dice = Random.value;        // If gets reward, the dice rolls once again to determine the reward (coin or powerUp).

            if (dice <= chanceToLootPowerUp)
                GetPowerUp();
            else
            {
                CalculateRandomInBezier();
                GetCoin();
            }
        }
    }

    void GetPowerUp()
    {
        float dice = Random.value * 100;            // Chance will be a value from 0 to 100, and random.value only returns values in the range 0-1.
        int pChance = (int)100 / powerUps.Length;   // Calculate proportionally to lenght, the chance to be given.

        for (int i = 0; i < powerUps.Length; i++)
            if (dice > pChance * i && dice <= pChance * (i + 1))
                CreateLoot(powerUps[i]);
    }

    void CalculateRandomInBezier()
    {
        curveRandomness = Mathf.Floor(bezierValue.Evaluate(Random.value) * 100);    // To give weight, we take a random a value from a curve.
    }

    void GetCoin()
    {
        if (coins.Length == 0) return;
        int nChance = (int)(100 / coins.Length);    // Distribute the weight between the items in the array.
        for (int i = 0; i < coins.Length; i++)
        {
            if (curveRandomness > nChance * i && curveRandomness <= nChance * (i + 1))
            {
                CreateLoot(coins[i]);
            }
        }
    }

    void CreateLoot(ItemSO obj)
    {
        if (obj != null) Instantiate(obj.itemPrefab, this.transform.position, Quaternion.identity);
        else return;
    }


}
