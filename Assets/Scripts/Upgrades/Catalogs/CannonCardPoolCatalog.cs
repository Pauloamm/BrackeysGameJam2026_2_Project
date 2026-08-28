using System.Collections.Generic;
using UnityEngine;

public class CannonCardPoolCatalog : CardPoolCatalogBase
{
    [SerializeField] private CannonManager manager;
    [SerializeField] private Sprite icon;

    [SerializeField] private float damageAmount = 1f;
    [SerializeField] private float fireRatePercentage = 0.2f;
    [SerializeField] private float projectileSpeedAmount = 1f;
    [SerializeField] private int bounceAmount = 1;
    [SerializeField] private int capAmount = 1;
    [SerializeField] private int overchargeAmount = 1;

    protected override List<UpgradeCard> CreateCards()
    {
        return new List<UpgradeCard>
        {
            new UpgradeCard("Cannon", "Damage up", $"+{damageAmount} damage", icon,
                () => manager.AddDamage(damageAmount)),
            new UpgradeCard("Cannon", "Fire rate up", $"+{fireRatePercentage:P0} fire rate", icon,
                () => manager.AddFireRate(fireRatePercentage)),
            new UpgradeCard("Cannon", "Projectile speed up", $"+{projectileSpeedAmount} projectile speed", icon,
                () => manager.AddProjectileSpeed(projectileSpeedAmount)),
            new UpgradeCard("Cannon", "Bounce", "+1 bounce off walls/enemies", icon,
                () => manager.AddBounce(bounceAmount)),
            new UpgradeCard("Cannon", "+1 max Cannon deployed", "Deploy one more Cannon", icon,
                () => manager.AddCap(capAmount)),
            //new UpgradeCard("Cannon", "Overcharge", "Bigger hitbox/damage — riskiest pick", icon,
            //    () => manager.AddOverchargeStack(overchargeAmount)),
        };
    }
}