using UnityEngine;

public class AegisTurret : TurretBase<AegisStats>
{
    [SerializeField] private AegisOrb orbPrefab;
    [SerializeField] private Transform firePoint;

    protected override void Fire()
    {
        if (target == null) return;

        Vector2 direction = (target.position - firePoint.position).normalized;

        AegisOrb orb = Instantiate(orbPrefab, firePoint.position, Quaternion.identity);
        orb.Launch(direction, currentStats.damage, currentStats.projectileSpeed);
    }

    protected override float GetCooldownDuration()
    {
        return currentStats.cooldownDuration;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        SetTarget(other.transform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        if (target == other.transform)
        {
            SetTarget(null);
        }
    }
}
