using UnityEngine;

public class PylonManager : TurretManagerBase<PylonStats, PylonTurret>
{
    [SerializeField] private PylonStats pylonStatsTemplate;

    private void Awake()
    {
        currentStats = Instantiate(pylonStatsTemplate);
    }

    public void AddDamage(float amount)
    {
        currentStats.damage += amount;
        PushStatsToActiveTurrets();
    }

    public void AddFireRate(float percentage)
    {
        currentStats.cooldownDuration -= currentStats.cooldownDuration * percentage;
        PushStatsToActiveTurrets();
    }

    public void AddProjectileSpeed(float amount)
    {
        AddRotationSpeed(amount);
    }

    public void AddBeamRange(float amount)
    {
        currentStats.beamRange += amount;
        PushStatsToActiveTurrets();
    }

    public void AddBeamCount(int amount = 1)
    {
        currentStats.beamCount += amount;
        PushStatsToActiveTurrets();
    }

    public void AddCap(int amount = 1)
    {
        capBonus += amount;
    }

    public void AddOverchargeStack(int amount = 1)
    {
        currentStats.overchargeStacks += amount;
        PushStatsToActiveTurrets();
    }

    private void AddRotationSpeed(float amount)
    {
        currentStats.projectileSpeed += amount;
        PushStatsToActiveTurrets();
    }
}
