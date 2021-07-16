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
    [SerializeField] ItemSO[] items;
    [Tooltip("The randomness will take values from a curve.")]
    [SerializeField] AnimationCurve bezierValue;
    float curveRandomness;

    private void Start()
    {
        if (items.Length == 0) Debug.LogWarning("<b><color=blue>Items array is empty</color></b> in " + gameObject.name);
    }

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
            CalculateRandomInBezier();
            GetCoin();
        }
    }

    // void GetPowerUp()
    // {
    // }

    void CalculateRandomInBezier()
    {
        curveRandomness = Mathf.Floor(bezierValue.Evaluate(Random.value) * 100);    // To give weight, we take a random a value from a curve.
    }

    void GetCoin()
    {
        if (items.Length == 0) return;
        int nChance = (int)(100 / items.Length);    // Distribute the weight between the items in the array.

        for (int i = 0; i < items.Length; i++)
        {
            if (curveRandomness > nChance * i && curveRandomness <= nChance * (i + 1))
                CreateCoin(items[i]);
        }
    }

    void CreateCoin(ItemSO obj)
    {
        if (obj != null) Instantiate(obj.itemPrefab, this.transform.position, Quaternion.identity);
        else return;
    }

}
