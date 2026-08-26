using UnityEngine;

public class RusherEnemy : EnemyBase<RusherStats>
{
    [SerializeField] private EnemyMovementBehaviour movementBehaviour;

    public override void SetTarget(Transform newTarget)
    {
        base.SetTarget(newTarget);
        movementBehaviour.SetTarget(newTarget);
    }

    protected override void OnStatsApplied()
    {
        movementBehaviour.SetMoveSpeed(currentStats.moveSpeed);
    }

    private void Update()
    {
        if (CheckForDeathState())
        {
            return;
        }

        movementBehaviour.MoveTowardsTarget();
    }
}
