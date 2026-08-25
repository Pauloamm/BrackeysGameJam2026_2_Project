using UnityEngine;

public abstract class TurretBase<TStats> : MonoBehaviour
{
    protected TStats currentStats;
    protected Transform target;

    private float cooldownTimer;

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0f)
        {
            Fire();
            cooldownTimer = GetCooldownDuration();
        }
    }

    public void ApplyStats(TStats stats)
    {
        currentStats = stats;
        OnStatsApplied();
    }

    public virtual void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    protected abstract void Fire();

    protected abstract float GetCooldownDuration();

    // Called after currentStats is updated - override for type-specific reactions
    // (e.g. clamping the cooldown timer if fire rate just increased mid-cooldown)
    protected virtual void OnStatsApplied() { }
}