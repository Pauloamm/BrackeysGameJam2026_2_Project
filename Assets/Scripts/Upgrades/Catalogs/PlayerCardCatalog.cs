using System.Collections.Generic;
using UnityEngine;

public class PlayerCardCatalog : CardPoolCatalogBase
{
    [SerializeField] private PlayerStatsManager manager;
    [SerializeField] private Sprite icon;

    [SerializeField] private int maxHealthAmount = 1;
    [SerializeField] private float moveSpeedAmount = 0.5f;
    [SerializeField] private int maxShieldsAmount = 1;

    protected override List<UpgradeCard> CreateCards()
    {
        return new List<UpgradeCard>
        {
            new UpgradeCard("Character", "Max HP up", $"+{maxHealthAmount} max HP", icon,
                () => manager.AddMaxHealth(maxHealthAmount)),
            new UpgradeCard("Character", "Move speed up", $"+{moveSpeedAmount} move speed", icon,
                () => manager.AddMoveSpeed(moveSpeedAmount)),
            new UpgradeCard("Character", "Max shields up", $"+{maxShieldsAmount} max shields", icon,
                () => manager.AddMaxShields(maxShieldsAmount)),
        };
    }
}