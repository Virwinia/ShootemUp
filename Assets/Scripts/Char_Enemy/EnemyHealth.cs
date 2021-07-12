
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] GiveRandomLoot looter;

    [ReadOnly] [SerializeField] int enemyHP, score;
    GameObject explosionDamage, explosionDeath;
    NpcDataHandler enemyData;

    private void Start()
    {
        enemyData = GetComponent<NpcDataHandler>();
        enemyHP = enemyData.health;
        score = enemyData.score;
        explosionDamage = enemyData.vfxDamage;
        explosionDeath = enemyData.vfxDeath;
    }

    public void TakeDamage(int damage)
    {
        enemyHP -= damage;

        if (enemyHP <= 0)
        {
            EnemyDeath();
        }
    }

    public void PositionEffectsInHit(Vector3 hitPosition)
    {
        if (explosionDamage != null)
            Instantiate(explosionDamage, hitPosition, Quaternion.identity);//instanciar explosion en el punto en el que entra el daño
        else Debug.LogWarning("Missing prefab reference explosionDamage in " + gameObject.name);
    }

    void EnemyDeath()
    {
        if (explosionDeath != null)
            Instantiate(explosionDeath, transform.position, Quaternion.identity);
        else Debug.LogWarning("Missing prefab reference explosionDeath in " + gameObject.name);

        AudioManager.audioManagerInstance.PlaySound(0);
        Destroy(gameObject);

        GiveScoreAndLoot();
    }

    void GiveScoreAndLoot()
    {
        looter.CalculateLootingChances();
        ScoreManager.scoreManager.AddScore(score);      // When enemy dies, gives score to the player
    }
}
