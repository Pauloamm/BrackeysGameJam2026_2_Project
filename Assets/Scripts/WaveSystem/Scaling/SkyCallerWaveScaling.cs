using UnityEngine;

[CreateAssetMenu(fileName = "SkyCallerWaveScaling", menuName = "WaveScaling/Sky Caller")]
public class SkyCallerWaveScaling : RangedEnemyWaveScaling
{
    [Header("AoE Damage Scaling")]
    [SerializeField] private int aoeDamageIncrementAmount = 1;
    [SerializeField] private int wavesPerAoeDamageIncrement = 2;

    [Header("Telegraph Duration Scaling")]
    [SerializeField] private float telegraphDurationIncrementAmount = 0f;
    [SerializeField] private int wavesPerTelegraphDurationIncrement = 1;

    [Header("AoE Radius Scaling")]
    [SerializeField] private float aoeRadiusIncrementAmount = 0f;
    [SerializeField] private int wavesPerAoeRadiusIncrement = 1;

    [Header("Fire Cooldown Scaling")]
    [SerializeField] private float fireCooldownPercentPerWave = 0.1f;
    [SerializeField] private float minFireCooldown = 0.5f;

    public int GetScaledAoeDamage(int baseAoeDamage, int waveNumber)
    {
        return SteppedLinear(baseAoeDamage, aoeDamageIncrementAmount, wavesPerAoeDamageIncrement, waveNumber);
    }

    public float GetScaledTelegraphDuration(float baseTelegraphDuration, int waveNumber)
    {
        return SteppedLinear(baseTelegraphDuration, telegraphDurationIncrementAmount, wavesPerTelegraphDurationIncrement, waveNumber);
    }

    public float GetScaledAoeRadius(float baseAoeRadius, int waveNumber)
    {
        return SteppedLinear(baseAoeRadius, aoeRadiusIncrementAmount, wavesPerAoeRadiusIncrement, waveNumber);
    }

    public float GetScaledFireCooldown(float baseFireCooldown, int waveNumber)
    {
        return Diminishing(baseFireCooldown, fireCooldownPercentPerWave, minFireCooldown, waveNumber);
    }
}