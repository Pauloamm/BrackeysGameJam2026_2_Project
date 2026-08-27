using System.Collections.Generic;
using UnityEngine;

public class RandomCardSelector : MonoBehaviour
{
    private const int TurretCardCount = 3;
    private const int PlayerCardCount = 1;

    [SerializeField] private CannonCardPoolCatalog cannonCatalog;
    [SerializeField] private ShotgunCardPoolCatalog shotgunCatalog;
    [SerializeField] private PylonCardPoolCatalog pylonCatalog;
    [SerializeField] private AegisCardPoolCatalog aegisCatalog;
    [SerializeField] private PlayerCardCatalog playerCatalog;

    public List<UpgradeCard> DrawCards()
    {
        List<UpgradeCard> turretPool = new List<UpgradeCard>();
        turretPool.AddRange(cannonCatalog.GetUpgradeCards());
        turretPool.AddRange(shotgunCatalog.GetUpgradeCards());
        turretPool.AddRange(pylonCatalog.GetUpgradeCards());
        turretPool.AddRange(aegisCatalog.GetUpgradeCards());

        List<UpgradeCard> cards = new List<UpgradeCard>(4);
        cards.AddRange(PickRandom(turretPool, TurretCardCount));
        cards.AddRange(PickRandom(playerCatalog.GetUpgradeCards(), PlayerCardCount));
        return cards;
    }

    private List<UpgradeCard> PickRandom(List<UpgradeCard> source, int count)
    {
        // Copy before removing — source is the catalog's own permanent list,
        // never the one to mutate in place.
        List<UpgradeCard> pool = new List<UpgradeCard>(source);
        List<UpgradeCard> picked = new List<UpgradeCard>();

        for (int i = 0; i < count && pool.Count > 0; i++)
        {
            int index = Random.Range(0, pool.Count);
            picked.Add(pool[index]);
            pool.RemoveAt(index);
        }

        return picked;
    }
}
