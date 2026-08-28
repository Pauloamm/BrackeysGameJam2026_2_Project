using UnityEngine;
using System;
using System.Collections;

public abstract class BaseSpawner : MonoBehaviour
{
    private const float TelegraphDuration = 1.5f;

    [SerializeField] protected float minSpawnDistance;
    [SerializeField] protected float maxSpawnDistance;
    [SerializeField] protected GameObject telegraphPrefab;
    [SerializeField] protected int maxPositionRerollAttempts = 5;

    protected Transform target;
    protected SpawnPositionRegistry spawnPositionRegistry;
    protected int totalBudget;
    protected int spawnedSoFar;
    protected int currentlyAlive;

    public event Action OnEnemyKilled;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void SetSpawnPositionRegistry(SpawnPositionRegistry registry)
    {
        spawnPositionRegistry = registry;
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

    protected void SpawnOne()
    {
        Vector2 spawnPosition = EnemySpawnPositionUtil.GetRandomPositionAroundTarget(target, minSpawnDistance, maxSpawnDistance);

        for (int attempt = 0; attempt < maxPositionRerollAttempts; attempt++)
        {
            if (spawnPositionRegistry.TryReservePosition(spawnPosition))
            {
                break;
            }

            spawnPosition = EnemySpawnPositionUtil.GetRandomPositionAroundTarget(target, minSpawnDistance, maxSpawnDistance);
        }

        GameObject telegraphInstance = Instantiate(telegraphPrefab, spawnPosition, Quaternion.identity);

        spawnedSoFar++;
        currentlyAlive++;

        StartCoroutine(SpawnAfterTelegraph(spawnPosition, telegraphInstance));
    }

    private IEnumerator SpawnAfterTelegraph(Vector2 spawnPosition, GameObject telegraphInstance)
    {
        yield return new WaitForSeconds(TelegraphDuration);

        spawnPositionRegistry.ReleasePosition(spawnPosition);
        Destroy(telegraphInstance);

        SpawnEnemyAt(spawnPosition);
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
    protected abstract void SpawnEnemyAt(Vector2 position);
    protected abstract int GetMaxConcurrent();
}