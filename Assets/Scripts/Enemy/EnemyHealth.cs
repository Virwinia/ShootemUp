
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] NpcSO npcSO;
    [ReadOnly] [SerializeField] int enemyHP, score;

    GameObject explosionDamage, explosionDeath;

    private void Start()
    {
        enemyHP = npcSO.health;
        score = npcSO.score;
        explosionDamage = npcSO.prefabExplosionDamage;
        explosionDeath = npcSO.prefabExplosionDeath;
    }

    public void RemoveHP(int damage, Vector3 v)
    {
        enemyHP -= damage;

        if (explosionDamage != null)
            Instantiate(explosionDamage, v, Quaternion.identity);//instanciar explosion en el punto en el que entra el daño
        else Debug.LogWarning("Missing prefab reference explosionDamage in " + gameObject.name);

        if (enemyHP <= 0)
        {
            EnemyDeath();
            GiveScoreAndLoot();
        }
    }

    void EnemyDeath()
    {
        if (explosionDeath != null)
            Instantiate(explosionDeath, transform.position, Quaternion.identity);
        else Debug.LogWarning("Missing prefab reference explosionDeath in " + gameObject.name);

        AudioManager.audioManagerInstance.PlaySound(0);
        Destroy(gameObject);
    }

    void GiveScoreAndLoot()
    {
        GetComponent<GiveRandomLoot>().CalculateLootingChances();
        ScoreManager.scoreManager.AddScore(score);      // When enemy dies, gives score to the player
    }
}
