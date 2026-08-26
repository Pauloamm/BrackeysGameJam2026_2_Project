using UnityEngine;

public class ShooterEnemy : EnemyBase<ShooterStats>
{
    [SerializeField] private EnemyMovementBehaviour movementBehaviour;
    [SerializeField] private EnemyShootingBehaviour shootingBehaviour;

    public override void SetTarget(Transform newTarget)
    {
        base.SetTarget(newTarget);
        movementBehaviour.SetTarget(newTarget);
        shootingBehaviour.SetTarget(newTarget);
    }

    protected override void OnStatsApplied()
    {
        movementBehaviour.SetMoveSpeed(currentStats.moveSpeed);
        movementBehaviour.SetStopDistance(currentStats.stopDistance);

        shootingBehaviour.SetProjectileSpeed(currentStats.projectileSpeed);
        shootingBehaviour.SetProjectileDamage(currentStats.projectileDamage);
        shootingBehaviour.SetCooldownDuration(currentStats.fireCooldown);
    }

    private void Update()
    {
        if (CheckForDeathState())
        {
            return;
        }

        if (movementBehaviour.IsWithinStopDistance())
        {
            currentState = EnemyState.Acting;

            if (shootingBehaviour.IsOffCooldown())
            {
                shootingBehaviour.Fire();
            }
        }
        else
        {
            currentState = EnemyState.Seeking;
            movementBehaviour.MoveTowardsTarget();
        }
    }
}
