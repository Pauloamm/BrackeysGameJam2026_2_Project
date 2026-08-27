using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField] private PlayerStats statsTemplate;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerLifeManager playerLifeManager;
    [SerializeField] private ShieldManager shieldManager;


    private PlayerStats currentStats;

    private const bool maxHPUpgradeHealsToFull = true;

    private void Awake()
    {
        currentStats = Instantiate(statsTemplate);

        playerMovement.SetMoveSpeed(currentStats.moveSpeed);
        playerLifeManager.SetMaxHealth(currentStats.maxHealth, maxHPUpgradeHealsToFull);
    }

    public void AddMoveSpeed(float amount)
    {
        currentStats.moveSpeed += amount;
        playerMovement.SetMoveSpeed(currentStats.moveSpeed);
    }

    public void AddMaxHealth(int amount)
    {
        currentStats.maxHealth += amount;
        playerLifeManager.SetMaxHealth(currentStats.maxHealth, maxHPUpgradeHealsToFull);
    }

    public void AddMaxShields(int amount)
    {
        currentStats.maxShields += amount;
        shieldManager.AddMaxShields(amount);
    }
}
