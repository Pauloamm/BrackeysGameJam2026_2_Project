using UnityEngine;
using System;

public abstract class BaseSpawner : MonoBehaviour
{
    [SerializeField] protected float minSpawnDistance;
    [SerializeField] protected float maxSpawnDistance;

    protected Transform target;
    protected int totalBudget;
    protected int spawnedSoFar;
    protected int currentlyAlive;

    public event Action OnEnemyKilled;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void StartWave(int waveNumber, int budget)
    {
        totalBudget = budget;
        spawnedSoFar = 0;
        currentlyAlive = 0;

        ApplyWaveScaling(waveNumber);

        int initialSpawnCount = Mathf.Min(GetMaxConcurrent(), totalBudget);
        for (int i = 0; i < initialSpawnCount; i++)
        {
            SpawnOne();
        }
    }

    protected void HandleEnemyDied()
    {
        currentlyAlive--;
        OnEnemyKilled?.Invoke();

        if (spawnedSoFar < totalBudget)
        {
            SpawnOne();
        }
    }

    protected abstract void ApplyWaveScaling(int waveNumber);
    protected abstract void SpawnOne();
    protected abstract int GetMaxConcurrent();
}