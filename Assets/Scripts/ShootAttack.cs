using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : MonoBehaviour
{
    public static ShootAttack ShootAttackInstance;
    Shooting[] bullets;

    private void Start()
    {
        ShootAttackInstance = this;
        bullets = GetComponentsInChildren<Shooting>();
    }

    public void Shoot()
    {
        foreach (Shooting shooting in bullets)
        {
            shooting.CreateProjectile();
        }
    }
}
