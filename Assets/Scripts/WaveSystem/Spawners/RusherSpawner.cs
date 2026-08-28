using UnityEngine;

public class RusherSpawner : BaseSpawner
{
    [SerializeField] private RusherEnemy enemyPrefab;
    [SerializeField] private RusherStats statsTemplate;
    [SerializeField] private RusherWaveScaling scalingTemplate;

    private RusherStats currentStats;

    private void Awake()
    {
        currentStats = Instantiate(statsTemplate);
    }

    protected override void ApplyWaveScaling(int waveNumber)
    {
        currentStats.maxHealth = scalingTemplate.GetScaledHealth(statsTemplate.maxHealth, waveNumber);
        currentStats.moveSpeed = scalingTemplate.GetScaledMoveSpeed(statsTemplate.moveSpeed, waveNumber);
        currentStats.contactDamage = scalingTemplate.GetScaledContactDamage(statsTemplate.contactDamage, waveNumber);
    }

    protected override int GetMaxConcurrent()
    {
        return scalingTemplate.GetMaxConcurrent();
    }

    protected override void SpawnEnemyAt(Vector2 position)
    {
        RusherEnemy enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        enemy.SetTarget(target);
        enemy.ApplyStats(currentStats);
        enemy.OnEnemyDeath += HandleEnemyDied;
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