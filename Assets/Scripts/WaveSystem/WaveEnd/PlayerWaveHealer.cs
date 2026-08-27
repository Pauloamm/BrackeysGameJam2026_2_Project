using UnityEngine;

public class PlayerWaveHealer : MonoBehaviour
{
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private PlayerLifeManager playerLifeManager;

    private void Awake()
    {
        waveManager.OnWaveCleared += HandleWaveCleared;
    }

    private void HandleWaveCleared()
    {
        playerLifeManager.HealToFull();
    }

    private void OnDestroy()
    {
        waveManager.OnWaveCleared -= HandleWaveCleared;
    }
}
