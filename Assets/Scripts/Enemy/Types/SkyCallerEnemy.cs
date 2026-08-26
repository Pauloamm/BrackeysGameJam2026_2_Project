using UnityEngine;

public class SkyCallerEnemy : EnemyBase<SkyCallerStats>
{
    [SerializeField] private EnemyMovementBehaviour movementBehaviour;
    [SerializeField] private EnemySkyCallingBehaviour skyCallingBehaviour;

    public override void SetTarget(Transform newTarget)
    {
        base.SetTarget(newTarget);
        movementBehaviour.SetTarget(newTarget);
        skyCallingBehaviour.SetTarget(newTarget);
    }

    protected override void OnStatsApplied()
    {
        movementBehaviour.SetMoveSpeed(currentStats.moveSpeed);
        movementBehaviour.SetStopDistance(currentStats.stopDistance);

        skyCallingBehaviour.SetAoeRadius(currentStats.aoeRadius);
        skyCallingBehaviour.SetAoeDamage(currentStats.aoeDamage);
        skyCallingBehaviour.SetTelegraphDuration(currentStats.telegraphDuration);
        skyCallingBehaviour.SetCooldownDuration(currentStats.fireCooldown);
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

            if (skyCallingBehaviour.IsOffCooldown())
            {
                skyCallingBehaviour.Fire();
            }
        }
        else
        {
            currentState = EnemyState.Seeking;
            movementBehaviour.MoveTowardsTarget();
        }
    }
}
