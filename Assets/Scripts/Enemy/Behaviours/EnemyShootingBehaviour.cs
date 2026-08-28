using UnityEngine;
using System;

public class EnemyShootingBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyShotProjectile projectilePrefab;

    private Transform target;
    private float projectileSpeed;
    private int projectileDamage;
    private float cooldownDuration;
    private float cooldownTimer;
    private Collider2D[] collidersToIgnore;

    public event Action OnFire;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    public void SetCollidersToIgnore(Collider2D[] colliders)
    {
        collidersToIgnore = colliders;
    }
    public void SetProjectileSpeed(float speed)
    {
        projectileSpeed = speed;
    }

    public void SetProjectileDamage(int damage)
    {
        projectileDamage = damage;
    }

    public void SetCooldownDuration(float duration)
    {
        cooldownDuration = duration;
    }

    private void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public bool IsOffCooldown()
    {
        return cooldownTimer <= 0f;
    }

    public void Fire()
    {
        Vector2 direction = ((Vector2)target.position - (Vector2)transform.position).normalized;
        EnemyShotProjectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.SetCollidersToIgnore(collidersToIgnore);
        projectile.Launch(direction, projectileSpeed, projectileDamage);

        cooldownTimer = cooldownDuration;

        OnFire?.Invoke();
    }
}