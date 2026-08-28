using UnityEngine;
using TMPro;

public class RunHudUIManager : MonoBehaviour
{
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private TMP_Text timerText;

    private void Awake()
    {
        waveManager.OnCurrentWaveChanged += HandleCurrentWaveChanged;
        waveManager.OnRunTimerChanged += HandleRunTimerChanged;
    }

    private void OnDestroy()
    {
        waveManager.OnCurrentWaveChanged -= HandleCurrentWaveChanged;
        waveManager.OnRunTimerChanged -= HandleRunTimerChanged;
    }

    private void HandleCurrentWaveChanged(int waveNumber)
    {
        waveText.text = $"Current Wave: {waveNumber}";
    }

    private void HandleRunTimerChanged(float runTimer)
    {
        int minutes = Mathf.FloorToInt(runTimer / 60f);
        int seconds = Mathf.FloorToInt(runTimer % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}