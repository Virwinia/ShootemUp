// THIS SCRIPT IS DEPRECATED

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Space]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] ItemSO coinData;

    [Space] [SerializeField] Vector2 gravity;

    [Space] [ReadOnly] [SerializeField] int score;
    Vector2 position;


    private void Awake()
    {
        score = coinData.score;
        position = this.gameObject.transform.position;
    }

    void Start()
    {
        rb.velocity = gravity;
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
        AudioManager.audioManagerInstance.PlaySound(3);
        Destroy(gameObject);
    }
}