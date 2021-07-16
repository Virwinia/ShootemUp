using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ShootemUp/NewItem", order = 2)]

public class ItemSO : ScriptableObject
{
    public int id;
    [Space] public string itemName;
    public int score;
    [Space] public GameObject itemPrefab;

    private void Awake()
    {
        if (itemPrefab == null)
            Debug.LogWarning(itemName + " scriptable object misses reference to game object.");
    }

}
