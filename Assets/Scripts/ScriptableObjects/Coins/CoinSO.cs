using UnityEngine;

[CreateAssetMenu(fileName = "CoinData", menuName = "ShootemUp/NewCoin", order = 2)]

public class CoinSO : ScriptableObject
{
    public int id;
    [Space] public string coinName;
    public int score;
    [Space] public GameObject coinPrefab;

    private void Awake()
    {
        if (coinPrefab == null)
            Debug.LogWarning(coinName + " scriptable object misses reference to game object.");
    }

}
