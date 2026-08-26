using UnityEngine;

public abstract class WaveScalingBase : ScriptableObject
{
    [Header("Health Scaling")]
    [SerializeField] private int healthIncrementAmount = 1;
    [SerializeField] private int wavesPerHealthIncrement = 1;

    [Header("Contact Damage Scaling")]
    [SerializeField] private int contactDamageIncrementAmount = 1;
    [SerializeField] private int wavesPerContactDamageIncrement = 2;

    [Header("Move Speed Scaling")]
    [SerializeField] private float moveSpeedIncrementAmount = 0f;
    [SerializeField] private int wavesPerMoveSpeedIncrement = 1;

    [Header("Spawn Cap")]
    [SerializeField] private int maxConcurrent = 7;

    public int GetScaledHealth(int baseHealth, int waveNumber)
    {
        return SteppedLinear(baseHealth, healthIncrementAmount, wavesPerHealthIncrement, waveNumber);
    }

    public int GetScaledContactDamage(int baseContactDamage, int waveNumber)
    {
        return SteppedLinear(baseContactDamage, contactDamageIncrementAmount, wavesPerContactDamageIncrement, waveNumber);
    }

    public float GetScaledMoveSpeed(float baseMoveSpeed, int waveNumber)
    {
        return SteppedLinear(baseMoveSpeed, moveSpeedIncrementAmount, wavesPerMoveSpeedIncrement, waveNumber);
    }

    public int GetMaxConcurrent()
    {
        return maxConcurrent;
    }

    protected int WaveNumberToNumberOfElapsedWaves(int waveNumber)
    {
        return waveNumber - 1;
    }

    protected int SteppedLinear(int baseValue, int incrementAmount, int wavesPerIncrement, int waveNumber)
    {
        return baseValue + (WaveNumberToNumberOfElapsedWaves(waveNumber) / wavesPerIncrement) * incrementAmount;
    }

    protected float SteppedLinear(float baseValue, float incrementAmount, int wavesPerIncrement, int waveNumber)
    {
        return baseValue + (WaveNumberToNumberOfElapsedWaves(waveNumber) / wavesPerIncrement) * incrementAmount;
    }

    protected float Diminishing(float baseValue, float percentPerWave, float minValue, int waveNumber)
    {
        return Mathf.Max(minValue, baseValue * Mathf.Pow(1 - percentPerWave, WaveNumberToNumberOfElapsedWaves(waveNumber)));
    }
}