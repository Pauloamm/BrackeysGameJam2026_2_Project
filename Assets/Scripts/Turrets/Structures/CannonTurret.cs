using UnityEngine;

public class CannonTurret : TurretBase<CannonStats>
{
    [SerializeField] private ShotProjectile projectilePrefab;

    [SerializeField] private Transform firePoint;

    protected override void Fire()
    {
        Vector2 direction = (target.position - firePoint.position).normalized;

        ShotProjectile projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.Launch(direction, currentStats.damage, currentStats.projectileSpeed, currentStats.bounceCount);
    }

    protected override float GetCooldownDuration()
    {
        return currentStats.cooldownDuration;
    }
}
