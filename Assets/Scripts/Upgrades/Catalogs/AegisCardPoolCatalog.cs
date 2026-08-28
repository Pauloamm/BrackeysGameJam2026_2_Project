using System.Collections.Generic;
using UnityEngine;

public class AegisCardPoolCatalog : CardPoolCatalogBase
{
    [SerializeField] private AegisManager manager;
    [SerializeField] private Sprite icon;

    [SerializeField] private float shieldStrengthAmount = 1f;
    [SerializeField] private float fireRatePercentage = 0.1f;
    [SerializeField] private float orbSpeedDecreaseAmount = 0.1f;
    [SerializeField] private int capAmount = 1;
    [SerializeField] private int overchargeAmount = 1;

    protected override List<UpgradeCard> CreateCards()
    {
        return new List<UpgradeCard>
        {
            new UpgradeCard("Aegis", "Shield strength up", $"+{shieldStrengthAmount} shield strength", icon,
                () => manager.AddShieldStrength(shieldStrengthAmount)),
            new UpgradeCard("Aegis", "Cooldown down", $"+{fireRatePercentage:P0} fire rate", icon,
                () => manager.AddFireRate(fireRatePercentage)),
            new UpgradeCard("Aegis", "Orb speed down", $"Easier to catch by {orbSpeedDecreaseAmount:P0}", icon,
                () => manager.AddOrbSpeed(orbSpeedDecreaseAmount)),
            new UpgradeCard("Aegis", "+1 max Aegis deployed", "Deploy one more Aegis", icon,
                () => manager.AddCap(capAmount)),
            //new UpgradeCard("Aegis", "Overcharge", "Bigger shield granted (and stolen)", icon,
            //    () => manager.AddOverchargeStack(overchargeAmount)),
        };
    }
}