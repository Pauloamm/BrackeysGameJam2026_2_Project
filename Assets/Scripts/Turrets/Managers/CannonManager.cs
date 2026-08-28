using UnityEngine;

public class CannonManager : TurretManagerBase<CannonStats, CannonTurret>
{

    [SerializeField] private CannonStats cannonStatsTemplate;
    private void Awake()
    {
        currentStats = Instantiate(cannonStatsTemplate);
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
        currentStats.projectileSpeed += amount;
        PushStatsToActiveTurrets();
    }

    public void AddBounce(int amount = 1)
    {
        currentStats.bounceCount += amount;
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