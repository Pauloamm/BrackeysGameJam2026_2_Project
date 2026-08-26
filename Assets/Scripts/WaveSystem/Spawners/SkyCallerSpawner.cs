using UnityEngine;

public class SkyCallerSpawner : BaseSpawner
{
    [SerializeField] private SkyCallerEnemy enemyPrefab;
    [SerializeField] private SkyCallerStats statsTemplate;
    [SerializeField] private SkyCallerWaveScaling scalingTemplate;

    private SkyCallerStats currentStats;

    private void Awake()
    {
        currentStats = Instantiate(statsTemplate);
    }

    protected override void ApplyWaveScaling(int waveNumber)
    {
        currentStats.maxHealth = scalingTemplate.GetScaledHealth(statsTemplate.maxHealth, waveNumber);
        currentStats.moveSpeed = scalingTemplate.GetScaledMoveSpeed(statsTemplate.moveSpeed, waveNumber);
        currentStats.stopDistance = scalingTemplate.GetScaledStopDistance(statsTemplate.stopDistance, waveNumber);
        currentStats.contactDamage = scalingTemplate.GetScaledContactDamage(statsTemplate.contactDamage, waveNumber);
        currentStats.aoeDamage = scalingTemplate.GetScaledAoeDamage(statsTemplate.aoeDamage, waveNumber);
        currentStats.telegraphDuration = scalingTemplate.GetScaledTelegraphDuration(statsTemplate.telegraphDuration, waveNumber);
        currentStats.aoeRadius = scalingTemplate.GetScaledAoeRadius(statsTemplate.aoeRadius, waveNumber);
        currentStats.fireCooldown = scalingTemplate.GetScaledFireCooldown(statsTemplate.fireCooldown, waveNumber);
    }

    protected override int GetMaxConcurrent()
    {
        return scalingTemplate.GetMaxConcurrent();
    }

    protected override void SpawnOne()
    {
        Vector2 spawnPosition = EnemySpawnPositionUtil.GetRandomPositionAroundTarget(target, minSpawnDistance, maxSpawnDistance);

        SkyCallerEnemy enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.SetTarget(target);
        enemy.ApplyStats(currentStats);
        enemy.OnEnemyDeath += HandleEnemyDied;

        spawnedSoFar++;
        currentlyAlive++;
    }

    [ContextMenu("Spawn Test Enemy")]
    private void SpawnTestEnemy()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        if (currentStats == null)
        {
            currentStats = Instantiate(statsTemplate);
        }

        SpawnOne();
    }
}