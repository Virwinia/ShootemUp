using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDataHandler : MonoBehaviour
{
    [SerializeField] NpcSO npcData;
    [HideInInspector] public float chanceToLoot;
    [HideInInspector] public int fireRate, health, score, amountCannons;
    [HideInInspector] public GameObject vfxDamage, vfxDeath;

    private void Awake()
    {
        // Weapons
        amountCannons = npcData.amountCannons;
        fireRate = npcData.fireRate;
        // Ship data
        health = npcData.health;
        vfxDamage = npcData.prefabExplosionDamage;
        vfxDeath = npcData.prefabExplosionDeath;
        // Loot
        score = npcData.score;
        chanceToLoot = npcData.chanceToLoot;


    }

}
