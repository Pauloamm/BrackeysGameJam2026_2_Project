using UnityEngine;

public class ShotgunManager : TurretManagerBase<ShotgunStats, ShotgunTurret>
{
    [SerializeField] private ShotgunStats shotgunStatsTemplate;

    private void Awake()
    {
        currentStats = Instantiate(shotgunStatsTemplate);
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

    public void AddPelletCount(int amount = 1)
    {
        currentStats.pelletCount += amount;
        PushStatsToActiveTurrets();
    }

    public void AddConeAngle(float amount)
    {
        currentStats.coneAngle += amount;
        PushStatsToActiveTurrets();
    }

    public void AddPierce(int amount = 1)
    {
        currentStats.pierceCount += amount;
        PushStatsToActiveTurrets();
    }

    public void AddRange(float amount)
    {
        currentStats.range += amount;
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
}
