using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDataHandler : MonoBehaviour
{
    [SerializeField] NpcSO npcData;
    [HideInInspector] public float chanceToLoot;
    [HideInInspector] public int fireRate, health, score, amountCannons;

    private void Awake()
    {
        // Weapons
        amountCannons = npcData.amountCannons;
        fireRate = npcData.fireRate;
        // Ship data
        health = npcData.health;
        // Loot
        score = npcData.score;
        chanceToLoot = npcData.chanceToLoot;
    }

}
