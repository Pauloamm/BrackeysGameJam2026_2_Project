using System.Collections.Generic;
using UnityEngine;

public class ShotgunCardPoolCatalog : CardPoolCatalogBase
{
    [SerializeField] private ShotgunManager manager;
    [SerializeField] private Sprite icon;

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
            new UpgradeCard("Shotgun", "Damage up", $"+{damageAmount} damage", icon,
                () => manager.AddDamage(damageAmount)),
            new UpgradeCard("Shotgun", "Fire rate up", $"+{fireRatePercentage:P0} fire rate", icon,
                () => manager.AddFireRate(fireRatePercentage)),
            new UpgradeCard("Shotgun", "More pellets", $"+{pelletAmount} pellet", icon,
                () => manager.AddPelletCount(pelletAmount)),
            new UpgradeCard("Shotgun", "Wider cone", $"+{coneAngleAmount} degree cone angle", icon,
                () => manager.AddConeAngle(coneAngleAmount)),
            new UpgradeCard("Shotgun", "Pierce", "Pellets continue through enemies", icon,
                () => manager.AddPierce(pierceAmount)),
            new UpgradeCard("Shotgun", "Range up", $"+{rangeAmount} range", icon,
                () => manager.AddRange(rangeAmount)),
            new UpgradeCard("Shotgun", "+1 max Shotgun deployed", "Deploy one more Shotgun", icon,
                () => manager.AddCap(capAmount)),
            //new UpgradeCard("Shotgun", "Overcharge", "Bigger bullets — riskiest pick", icon,
            //    () => manager.AddOverchargeStack(overchargeAmount)),
        };
    }
}