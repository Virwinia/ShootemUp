//
// When the bullet impacts any damageable, it plays anim_damage (explosion).
// The anim stops playing in the last frame it has, and sprite remains in scene.
// To kill that sprite, this scripts must be used in the prefabAnim.

using UnityEngine;

public class KillBulletImpact : MonoBehaviour
{
    public void Death()
    {
        Destroy(gameObject);
    }
}
