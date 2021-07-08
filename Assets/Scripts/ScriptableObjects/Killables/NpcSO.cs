
using UnityEngine;

[CreateAssetMenu(fileName = "Npc_Data_", menuName = "ShootemUp/NewNpc", order = 3)]
public class NpcSO : ScriptableObject
{
    [Space] public int id;

    [Space]
    [Header("Ship Data ---")]
    public string npcName;
    public int level, weight, amountCannons, fireRate;

    [Space]
    [Header("Health --")]
    public int health;
    public int score;
    public float chanceToLoot;

    [Space]
    [Header("Movement --")]
    public float speed;
    public float amplitude, alphaDelta; // ---> NOTA A FUTURO: INTENTAR SIMPLIFICAR ESTOS DATOS

    [Space]
    [Header("Particles --")]
    public GameObject prefabExplosionDamage; // --> NOTA A FUTURO: ESTO DEBERÍA DARLO LA BALA
    public GameObject prefabExplosionDeath;


}
