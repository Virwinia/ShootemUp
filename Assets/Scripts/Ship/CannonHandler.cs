
using UnityEngine;

public class CannonHandler : MonoBehaviour
{
    [SerializeField] Shooting[] cannons;
    int activeCannons;

    private void Awake()
    {
        cannons = GetComponentsInChildren<Shooting>();
        PlayerDataHandler playerData = GetComponent<PlayerDataHandler>();
        activeCannons = playerData.amountCannons;
        DeactivateCannons(activeCannons);
    }


    void DeactivateCannons(int activeCannons)
    {
        for (int i = activeCannons; i < cannons.Length; i++)
            cannons[i].gameObject.SetActive(false);
    }
}
