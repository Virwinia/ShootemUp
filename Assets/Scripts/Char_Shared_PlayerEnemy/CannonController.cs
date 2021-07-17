
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [ReadOnly] public Shooting[] cannons;
    bool isPlayer, isEnemy;

    private void Start()
    {
        // Set active cannons for the Player and Npcs
        if (gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_PLAYER))
        {
            cannons = GetComponentsInChildren<Shooting>();
            DeactivateCannons(PlayerDataHandler.playerDataInstance.amountCannons);
        }
        else if (gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_ENEMY))
        {
            if (cannons != null)
                cannons = GetComponentsInChildren<Shooting>();
            else Debug.LogWarning("Missing Shooting component in children cannons");
            DeactivateCannons(GetComponent<NpcDataHandler>().amountCannons);
        }
    }

    void DeactivateCannons(int activeCannons)
    {
        for (int i = activeCannons; i < cannons.Length; i++)
        {
            cannons[i].gameObject.SetActive(false);
        }
    }


}
