using System.Collections.Generic;
using UnityEngine;

public class PylonCardPoolCatalog : CardPoolCatalogBase
{
    [SerializeField] private PylonManager manager;
    [SerializeField] private Sprite icon;

    [SerializeField] private float damageAmount = 1f;
    [SerializeField] private float rotationSpeedAmount = 1f;
    [SerializeField] private float beamRangeAmount = 1f;
    [SerializeField] private float fireRatePercentage = 0.1f;
    [SerializeField] private int beamCountAmount = 1;
    [SerializeField] private int capAmount = 1;
    [SerializeField] private int overchargeAmount = 1;

    protected override List<UpgradeCard> CreateCards()
    {
        return new List<UpgradeCard>
        {
            new UpgradeCard("Pylon", "Damage up", $"+{damageAmount} damage", icon,
                () => manager.AddDamage(damageAmount)),
            new UpgradeCard("Pylon", "Rotation speed up", $"+{rotationSpeedAmount} rotation speed", icon,
                () => manager.AddProjectileSpeed(rotationSpeedAmount)),
            new UpgradeCard("Pylon", "Beam range up", $"+{beamRangeAmount} beam range", icon,
                () => manager.AddBeamRange(beamRangeAmount)),
            new UpgradeCard("Pylon", "Cooldown down", $"+{fireRatePercentage:P0} fire rate", icon,
                () => manager.AddFireRate(fireRatePercentage)),
            new UpgradeCard("Pylon", "+1 beam", "Adds another sweeping beam", icon,
                () => manager.AddBeamCount(beamCountAmount)),
            new UpgradeCard("Pylon", "+1 max Pylon deployed", "Deploy one more Pylon", icon,
                () => manager.AddCap(capAmount)),
            //new UpgradeCard("Pylon", "Overcharge", "Bigger hitbox/damage — riskiest pick", icon,
            //    () => manager.AddOverchargeStack(overchargeAmount)),
        };
    }
}