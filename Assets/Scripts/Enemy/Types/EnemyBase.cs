using UnityEngine;
using System;

public enum EnemyState
{
    Seeking,
    Acting,
    Dead
}

public abstract class EnemyBase<TStats> : MonoBehaviour where TStats : EnemyBaseStats
{
    [SerializeField] protected EnemyHealthSystem healthSystem;
    [SerializeField] protected EnemyContactDamageBehaviour contactDamageBehaviour;

    protected TStats currentStats;
    protected Transform target;
    protected EnemyState currentState = EnemyState.Seeking;

    public event Action OnEnemyDeath;

    protected virtual void Awake()
    {
        healthSystem.OnDeath += Die;
    }

    protected virtual void OnDestroy()
    {
        healthSystem.OnDeath -= Die;
    }

    public virtual void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public virtual void ApplyStats(TStats stats)
    {
        currentStats = stats;
        healthSystem.Initialize(currentStats.maxHealth);
        contactDamageBehaviour.SetContactDamage(currentStats.contactDamage);
        OnStatsApplied();
    }

    protected abstract void OnStatsApplied();

    protected bool CheckForDeathState()
    {
        return currentState == EnemyState.Dead;
    }

    protected virtual void Die()
    {
        currentState = EnemyState.Dead;
        OnEnemyDeath?.Invoke();
        Destroy(gameObject);
    }
}