
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] NpcSO npcSO;
    [SerializeField] GiveRandomLoot looter;

    [ReadOnly] [SerializeField] int enemyHP, score;
    GameObject explosionDamage, explosionDeath;

    private void Start()
    {
        enemyHP = npcSO.health;
        score = npcSO.score;
        explosionDamage = npcSO.prefabExplosionDamage;
        explosionDeath = npcSO.prefabExplosionDeath;
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
