using UnityEngine;

public class AegisManager : TurretManagerBase<AegisStats, AegisTurret>
{
    [SerializeField] private AegisStats aegisStatsTemplate;

    private void Awake()
    {
        currentStats = Instantiate(aegisStatsTemplate);
    }

    public void AddShieldStrength(float amount)
    {
        currentStats.damage += amount;
        PushStatsToActiveTurrets();
    }

    public void AddFireRate(float percentage)
    {
        currentStats.cooldownDuration -= currentStats.cooldownDuration * percentage;
        PushStatsToActiveTurrets();
    }

    public void AddOrbSpeed(float amount)
    {
        currentStats.projectileSpeed -= amount;
        PushStatsToActiveTurrets();
    }

    public void AddCap(int amount = 1)
    {
        capBonus += amount;
        NotifyDeployedCountChanged();
    }

    public void AddOverchargeStack(int amount = 1)
    {
        currentStats.overchargeStacks += amount;
        PushStatsToActiveTurrets();
    }
}