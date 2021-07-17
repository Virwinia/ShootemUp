
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    PlayerDataHandler playerData;
    Collider2D mCol;

    private void OnEnable()
    {
        AudioManager.audioManagerInstance.PlaySound(7);
        playerData = GetComponentInParent<PlayerDataHandler>();
        mCol = playerData.gameObject.GetComponent<Collider2D>();
        if (mCol != null) Invulnerability();
    }

    // Shield down
    private void OnDisable()
    {
        AudioManager.audioManagerInstance.PlaySound(8);

        // After the shield down, the Player is temporary invulnerable (requires feedback).
        Invoke("RestoreVulnerability", 0.25f);
    }


    void Invulnerability()
    {
        mCol.enabled = false;
    }

    void RestoreVulnerability()
    {
        mCol.enabled = true;
    }

}
