using UnityEngine;
using System;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private RusherSpawner rusherSpawner;
    [SerializeField] private ShooterSpawner shooterSpawner;
    [SerializeField] private SkyCallerSpawner skyCallerSpawner;
    [SerializeField] private CardSelectionManager cardSelectionManager;

    private int currentWave;
    private int enemiesRemainingThisWave;
    private int totalEnemiesKilled;
    private float runTimer;

    public event Action<int> OnCurrentWaveChanged;
    public event Action<float> OnRunTimerChanged;
    public event Action<int> OnEnemiesKilledChanged;

    public event Action OnWaveCleared;

    private void Start()
    {
        rusherSpawner.SetTarget(player);
        shooterSpawner.SetTarget(player);
        skyCallerSpawner.SetTarget(player);

        rusherSpawner.OnEnemyKilled += HandleEnemyKilled;
        shooterSpawner.OnEnemyKilled += HandleEnemyKilled;
        skyCallerSpawner.OnEnemyKilled += HandleEnemyKilled;
        cardSelectionManager.OnSelectionEnded += HandleSelectionEnded;

        StartNextWave();
    }

    private void Update()
    {
        runTimer += Time.deltaTime;
        OnRunTimerChanged?.Invoke(runTimer);
    }

    private void StartNextWave()
    {
        currentWave++;
        OnCurrentWaveChanged?.Invoke(currentWave);

        (int rusherCount, int shooterCount, int skyCallerCount) = GetWaveComposition(currentWave);
        enemiesRemainingThisWave = rusherCount + shooterCount + skyCallerCount;

        if (rusherCount > 0)
        {
            rusherSpawner.StartWave(currentWave, rusherCount);
        }

        if (shooterCount > 0)
        {
            shooterSpawner.StartWave(currentWave, shooterCount);
        }

        if (skyCallerCount > 0)
        {
            skyCallerSpawner.StartWave(currentWave, skyCallerCount);
        }
    }

    private (int rusher, int shooter, int skyCaller) GetWaveComposition(int wave)
    {
        if (wave == 1)
        {
            return (3, 0, 0);
        }

        if (wave == 2)
        {
            return (3, 2, 0);
        }

        if (wave == 3)
        {
            return (3, 3, 1);
        }

        int rusherCount = 3 + GetExtraCount(5, wave);
        int shooterCount = 3 + GetExtraCount(6, wave);
        int skyCallerCount = 3 + GetExtraCount(7, wave);

        return (rusherCount, shooterCount, skyCallerCount);
    }

    private int GetExtraCount(int firstIncreaseWave, int wave)
    {
        if (wave < firstIncreaseWave)
        {
            return 0;
        }

        return (wave - firstIncreaseWave) / 3 + 1;
    }

    private void HandleEnemyKilled()
    {
        enemiesRemainingThisWave--;
        totalEnemiesKilled++;
        OnEnemiesKilledChanged?.Invoke(totalEnemiesKilled);

        if (enemiesRemainingThisWave <= 0)
        {
            OnWaveCleared?.Invoke();
        }
    }

    private void HandleSelectionEnded()
    {
        StartNextWave();
    }

    private void OnDestroy()
    {
        cardSelectionManager.OnSelectionEnded -= HandleSelectionEnded;
    }
}