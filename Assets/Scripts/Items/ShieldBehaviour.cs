
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    PlayerDataHandler playerData;
    Collider2D mCol;

    private void Start()
    {
        playerData = GetComponentInParent<PlayerDataHandler>();
        mCol = playerData.gameObject.GetComponent<Collider2D>();

        // playerData.ShieldActivation += ShieldActivation;
    }

    private void OnEnable()
    {
        if (mCol != null) Invulnerability();
    }

    private void OnDisable()
    {
        // After the shield down, the Player is temporary invulnerable (requires feedback).
        Invoke("RestoreVulnerability", 0.5f);

        // playerData.ShieldActivation -= ShieldActivation;
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (!other.gameObject.CompareTag(StaticValues.TAG_PLAYER)
    //      && other.gameObject.CompareTag(StaticValues.LAYER_BULLET))
    //     {
    //         playerData.ShieldActivation(false);
    //     }
    // }

    void Invulnerability()
    {
        mCol.enabled = false;
    }

    void RestoreVulnerability()
    {
        mCol.enabled = true;
    }

    // void ShieldActivation()
    // {
    //     print("ACTIVATIUON!!");
    // }
}
