using UnityEngine;

public class ShotgunTurret : TurretBase<ShotgunStats>
{
    private const int noBounceCount = 0;

    [SerializeField] private ShotProjectile projectilePrefab;
    [SerializeField] private Transform firePoint;

    protected override void Fire()
    {
        Vector2 baseDirection = (target.position - firePoint.position).normalized;
        float baseAngle = Mathf.Atan2(baseDirection.y, baseDirection.x) * Mathf.Rad2Deg;

        int pelletCount = currentStats.pelletCount;
        float coneAngle = currentStats.coneAngle;
        float startAngle = baseAngle - (coneAngle / 2f);
        float angleStep = pelletCount > 1 ? coneAngle / (pelletCount - 1) : 0f;

        for (int i = 0; i < pelletCount; i++)
        {
            float angle = pelletCount > 1 ? startAngle + (angleStep * i) : baseAngle;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            ShotProjectile projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            projectile.Launch(direction, currentStats.damage, currentStats.projectileSpeed, noBounceCount, currentStats.pierceCount);
        }
    }

    protected override float GetCooldownDuration()
    {
        return currentStats.cooldownDuration;
    }
}
