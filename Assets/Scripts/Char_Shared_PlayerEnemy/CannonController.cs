
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [ReadOnly] public Shooting[] cannons;
    int activeCannons;
    bool isPlayer, isEnemy;

    private void Start()
    {
        if (gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_PLAYER))
        {
            cannons = GetComponentsInChildren<Shooting>();
            activeCannons = GetComponent<PlayerDataHandler>().amountCannons;
            DeactivateCannons(activeCannons);
        }
        else if (gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_ENEMY))
        {
            if (cannons != null)
                cannons = GetComponentsInChildren<Shooting>();
            else Debug.LogWarning("Missing Shooting component in children cannons");

            activeCannons = GetComponent<NpcDataHandler>().amountCannons;
            DeactivateCannons(activeCannons);
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
