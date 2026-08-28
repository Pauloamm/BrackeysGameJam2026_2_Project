using UnityEngine;

public class WaveFlowSFXPlayer : MonoBehaviour
{
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private PlayableSfxSettings waveClearedSfx;
    [SerializeField] private PlayableSfxSettings waveStartedSfx;

    private void OnEnable()
    {
        waveManager.OnWaveCleared += PlayWaveClearedSound;
        waveManager.OnWaveStarted += PlayWaveStartedSound;
    }

    private void OnDisable()
    {
        waveManager.OnWaveCleared -= PlayWaveClearedSound;
        waveManager.OnWaveStarted -= PlayWaveStartedSound;
    }

    private void PlayWaveClearedSound()
    {
        AudioManager.Instance.Play2DClip(waveClearedSfx);
    }

    private void PlayWaveStartedSound()
    {
        AudioManager.Instance.Play2DClip(waveStartedSfx);
    }
}
