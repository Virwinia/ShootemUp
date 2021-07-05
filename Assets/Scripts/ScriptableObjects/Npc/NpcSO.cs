
using UnityEngine;

[CreateAssetMenu(fileName = "Npc_Data_", menuName = "ShootemUp/NewNpc", order = 3)]
public class NpcSO : ScriptableObject
{
    [Space] public int id;
    [Space] public string npcName;
    public int level, weight, damage;
    [Space] [SerializeField] GameObject prefabNpc;

    [Space]
    [Header("Health --")]
    public int health;
    public int score;
    public float chanceToLoot;

    [Space]
    [Header("Movement --")]
    public float speed;
    public float amplitude, alphaDelta;

    [Space]
    [Header("Particles --")]
    public GameObject prefabExplosionDamage;
    public GameObject prefabExplosionDeath;


}
