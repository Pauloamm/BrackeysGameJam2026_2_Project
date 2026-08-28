using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathScreenUIManager : MonoBehaviour
{
    [SerializeField] private PlayerLifeManager playerLifeManager;
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private GameObject deathScreenRoot;
    [SerializeField] private GameObject inGameUIRoot;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    [SerializeField] private TMP_Text wavesSurvivedText;
    [SerializeField] private TMP_Text timeAliveText;
    [SerializeField] private TMP_Text enemiesKilledText;

    private int currentWave;
    private float runTimer;
    private int totalEnemiesKilled;

    private void Awake()
    {
        playerLifeManager.OnDeath += HandleDeath;

        waveManager.OnCurrentWaveChanged += HandleCurrentWaveChanged;
        waveManager.OnRunTimerChanged += HandleRunTimerChanged;
        waveManager.OnEnemiesKilledChanged += HandleEnemiesKilledChanged;

        mainMenuButton.onClick.AddListener(HandleMainMenuClicked);
        retryButton.onClick.AddListener(HandleRetryClicked);

        deathScreenRoot.SetActive(false);
    }

    private void HandleCurrentWaveChanged(int value)
    {
        currentWave = value;
    }

    private void HandleRunTimerChanged(float value)
    {
        runTimer = value;
    }

    private void HandleEnemiesKilledChanged(int value)
    {
        totalEnemiesKilled = value;
    }

    private void HandleDeath()
    {
        wavesSurvivedText.text = $"Waves survived: {currentWave}";
        timeAliveText.text = $"Time alive: {FormatTime(runTimer)}";
        enemiesKilledText.text = $"Enemies killed: {totalEnemiesKilled}";

        Time.timeScale = 0f;
        inGameUIRoot.SetActive(false);
        deathScreenRoot.SetActive(true);
    }

    private string FormatTime(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.FloorToInt(totalSeconds % 60f);
        return $"{minutes:00}:{seconds:00}";
    }

    private void HandleMainMenuClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    private void HandleRetryClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    }