using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Space]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] CoinSO coinData;

    [Space] [SerializeField] Vector3 coinVelocity;

    [Space] [ReadOnly] [SerializeField] int score;

    private void Awake()
    {
        score = coinData.score;
    }

    void Start()
    {
        rb.velocity = coinVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(StaticValues.LAYER_PLAYER))
        {
            ScoreManager.scoreManager.AddScore(score);
            CoinDeath();
        }
    }

    void CoinDeath()
    {
        // SoundFXManager.soundFXManagerInstance.PlaySound(2);
        Destroy(gameObject);
    }

}
