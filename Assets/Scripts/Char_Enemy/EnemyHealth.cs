
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    GiveRandomLoot looter;

    int enemyHP, score;
    GameObject explosionDamage, explosionDeath;
    NpcDataHandler enemyData;

    private void Start()
    {
        looter = GetComponent<GiveRandomLoot>();
        enemyData = GetComponent<NpcDataHandler>();
        SetEnemyData();
    }

    void SetEnemyData()
    {
        enemyHP = enemyData.health;
        score = enemyData.score;
        explosionDamage = enemyData.vfxDamage;
        explosionDeath = enemyData.vfxDeath;
    }

    void PositionEffectsInHit(float x, float y)
    {
        if (explosionDamage != null)
            Instantiate(explosionDamage, new Vector2(x, y), Quaternion.identity);
        else Debug.LogWarning("Missing prefab reference explosionDamage in " + gameObject.name);
    }

    public void TakeDamage(int damage, float x, float y)
    {
        PositionEffectsInHit(x, y);     // When the enemy takes damage, particles are created in such position,
        enemyHP -= damage;              // Bullet inflicts damage to enemyHealth,
        if (enemyHP <= 0) EnemyDeath(); // and enemy dies if health reaches to zero.



    }

    void EnemyDeath()
    {
        if (explosionDeath != null)
            Instantiate(explosionDeath, transform.position, Quaternion.identity);
        else Debug.LogWarning("Missing prefab reference explosionDeath in " + gameObject.name);

        AudioManager.audioManagerInstance.PlaySound(3);

        Destroy(gameObject);
        GiveScoreAndLoot();
    }

    void GiveScoreAndLoot()
    {
        looter.CalculateLootingChances();
        ScoreManager.scoreManager.AddScore(score);      // When enemy dies, gives score to the player
    }
}
