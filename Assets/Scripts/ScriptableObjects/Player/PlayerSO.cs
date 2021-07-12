
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ShootemUp/NewPlayer")]
public class PlayerSO : ScriptableObject
{
    [Space] [SerializeField] int id;
    [SerializeField] string playerName;
    public int scoreMax;
    public int score;

    [Space] public int level;
    [Space] public float speed;
    public int health, cannonAmount, fireRate;

    [Space]
    [SerializeField] Sprite playerShip;
    [SerializeField] GameObject prefabExplosionDeath;
    [SerializeField] GameObject prefabPlayer;

    public GameObject ExplosionDeath
    {
        get { return prefabExplosionDeath; }
    }

    public GameObject Player
    {
        get { return prefabPlayer; }
    }

}
