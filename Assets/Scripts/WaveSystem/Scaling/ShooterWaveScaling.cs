using UnityEngine;

[CreateAssetMenu(fileName = "ShooterWaveScaling", menuName = "WaveScaling/Shooter")]
public class ShooterWaveScaling : RangedEnemyWaveScaling
{
    [Header("Projectile Damage Scaling")]
    [SerializeField] private int projectileDamageIncrementAmount = 1;
    [SerializeField] private int wavesPerProjectileDamageIncrement = 1;

    [Header("Projectile Speed Scaling")]
    [SerializeField] private float projectileSpeedIncrementAmount = 0.1f;
    [SerializeField] private int wavesPerProjectileSpeedIncrement = 1;

    [Header("Fire Cooldown Scaling")]
    [SerializeField] private float fireCooldownPercentPerWave = 0.1f;
    [SerializeField] private float minFireCooldown = 0.5f;

    public int GetScaledProjectileDamage(int baseProjectileDamage, int waveNumber)
    {
        return SteppedLinear(baseProjectileDamage, projectileDamageIncrementAmount, wavesPerProjectileDamageIncrement, waveNumber);
    }

    public float GetScaledProjectileSpeed(float baseProjectileSpeed, int waveNumber)
    {
        return SteppedLinear(baseProjectileSpeed, projectileSpeedIncrementAmount, wavesPerProjectileSpeedIncrement, waveNumber);
    }

    public float GetScaledFireCooldown(float baseFireCooldown, int waveNumber)
    {
        return Diminishing(baseFireCooldown, fireCooldownPercentPerWave, minFireCooldown, waveNumber);
    }
}