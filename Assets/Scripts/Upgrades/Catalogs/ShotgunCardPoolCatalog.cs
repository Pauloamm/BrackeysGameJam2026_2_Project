using System.Collections.Generic;
using UnityEngine;

public class ShotgunCardPoolCatalog : CardPoolCatalogBase
{
    [SerializeField] private ShotgunManager manager;

    [SerializeField] private float damageAmount = 2f;
    [SerializeField] private float fireRatePercentage = 0.1f;
    [SerializeField] private int pelletAmount = 1;
    [SerializeField] private float coneAngleAmount = 10f;
    [SerializeField] private int pierceAmount = 1;
    [SerializeField] private float rangeAmount = 1f;
    [SerializeField] private int capAmount = 1;
    [SerializeField] private int overchargeAmount = 1;

    protected override List<UpgradeCard> CreateCards()
    {
        return new List<UpgradeCard>
        {
            new UpgradeCard("Shotgun", "Damage up", $"+{damageAmount} damage",
                () => manager.AddDamage(damageAmount)),
            new UpgradeCard("Shotgun", "Fire rate up", $"+{fireRatePercentage:P0} fire rate",
                () => manager.AddFireRate(fireRatePercentage)),
            new UpgradeCard("Shotgun", "More pellets", $"+{pelletAmount} pellet",
                () => manager.AddPelletCount(pelletAmount)),
            new UpgradeCard("Shotgun", "Wider cone", $"+{coneAngleAmount} degree cone angle",
                () => manager.AddConeAngle(coneAngleAmount)),
            new UpgradeCard("Shotgun", "Pierce", "Pellets continue through enemies",
                () => manager.AddPierce(pierceAmount)),
            new UpgradeCard("Shotgun", "Range up", $"+{rangeAmount} range",
                () => manager.AddRange(rangeAmount)),
            new UpgradeCard("Shotgun", "+1 max Shotgun deployed", "Deploy one more Shotgun",
                () => manager.AddCap(capAmount)),
            new UpgradeCard("Shotgun", "Overcharge", "Bigger bullets — riskiest pick",
                () => manager.AddOverchargeStack(overchargeAmount)),
        };
    }
}
