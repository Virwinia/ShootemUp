
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Shooting[] cannons;
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
            cannons = GetComponentsInChildren<Shooting>();
            activeCannons = GetComponent<NpcDataHandler>().amountCannons;
            DeactivateCannons(activeCannons);
        }
    }

    void DeactivateCannons(int activeCannons)
    {
        for (int i = activeCannons; i < cannons.Length; i++)
            cannons[i].gameObject.SetActive(false);
    }


}
