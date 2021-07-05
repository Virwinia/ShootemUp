
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ShootemUp/NewPlayer")]
public class PlayerSO : ScriptableObject
{
    [Space] [SerializeField] int id;
    [SerializeField] string playerName;

    [Space] public int level;
    public Sprite playerShip;

    [Space] public float speed;
    public int health, cannonAmount, fireRate;

}
