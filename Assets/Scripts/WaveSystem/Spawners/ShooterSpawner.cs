using UnityEngine;

public class ShooterSpawner : BaseSpawner
{
    [SerializeField] private ShooterEnemy enemyPrefab;
    [SerializeField] private ShooterStats statsTemplate;
    [SerializeField] private ShooterWaveScaling scalingTemplate;

    private ShooterStats currentStats;

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
        currentStats.projectileDamage = scalingTemplate.GetScaledProjectileDamage(statsTemplate.projectileDamage, waveNumber);
        currentStats.fireCooldown = scalingTemplate.GetScaledFireCooldown(statsTemplate.fireCooldown, waveNumber);
        currentStats.projectileSpeed = scalingTemplate.GetScaledProjectileSpeed(statsTemplate.projectileSpeed, waveNumber);
    }

    protected override int GetMaxConcurrent()
    {
        return scalingTemplate.GetMaxConcurrent();
    }

    protected override void SpawnOne()
    {
        Vector2 spawnPosition = EnemySpawnPositionUtil.GetRandomPositionAroundTarget(target, minSpawnDistance, maxSpawnDistance);

        ShooterEnemy enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
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