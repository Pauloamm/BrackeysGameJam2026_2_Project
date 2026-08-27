using System.Collections.Generic;
using UnityEngine;

public abstract class CardPoolCatalogBase : MonoBehaviour
{
    private List<UpgradeCard> cards;

    private void Awake()
    {
        cards = CreateCards();
    }

    protected abstract List<UpgradeCard> CreateCards();

    public List<UpgradeCard> GetUpgradeCards() => cards;
}
