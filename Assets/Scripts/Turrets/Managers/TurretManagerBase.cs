using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretManagerBase<TStats, TTurret> : MonoBehaviour, ITurretSpawner
    where TTurret : TurretBase<TStats>
{
    [SerializeField] protected TTurret turretPrefab;
    [SerializeField] protected Transform targetReference;
    [SerializeField] protected int baseCap = 1;

    protected TStats currentStats;
    protected int capBonus;

    private readonly Queue<TTurret> activeTurrets = new Queue<TTurret>();

    public int CurrentCap => baseCap + capBonus;
    public int CurrentDeployedCount => activeTurrets.Count;
    public event Action<int, int> OnDeployedCountChanged;

    public TTurret SpawnTurret(Vector3 position, Quaternion rotation)
    {
        if (activeTurrets.Count >= CurrentCap)
        {
            DestroyOldestTurret();
        }

        TTurret turret = Instantiate(turretPrefab, position, rotation);
        turret.SetTarget(targetReference);
        turret.ApplyStats(currentStats);
        activeTurrets.Enqueue(turret);

        NotifyDeployedCountChanged();

        return turret;
    }

    public void SpawnTurretAt(Vector3 position, Quaternion rotation)
    {
        SpawnTurret(position, rotation);
    }

    protected void PushStatsToActiveTurrets()
    {
        foreach (TTurret turret in activeTurrets)
        {
            turret.ApplyStats(currentStats);
        }
    }

    protected void NotifyDeployedCountChanged()
    {
        OnDeployedCountChanged?.Invoke(activeTurrets.Count, CurrentCap);
    }

    private void DestroyOldestTurret()
    {
        if (activeTurrets.Count == 0) return;

        TTurret oldest = activeTurrets.Dequeue();

        if (oldest != null)
        {
            Destroy(oldest.gameObject);
        }
    }
}