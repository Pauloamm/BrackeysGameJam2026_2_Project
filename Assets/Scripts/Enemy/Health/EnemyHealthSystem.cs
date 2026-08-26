using UnityEngine;
using System;

/// <summary>
/// IDamageable implementer for enemies. Lives on a child GameObject per the
/// interface-placement convention. Checks a sibling ShieldManager first -
/// if a shield blocks the hit, health is untouched. ShieldManager itself
/// stays unaware this component exists; the dependency only goes one way.
/// </summary>
public class EnemyHealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] private ShieldManager shieldManager;

    private int currentHealth;

    public event Action OnDamaged;
    public event Action OnDeath;

    public void Initialize(int maxHealth)
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (shieldManager != null && shieldManager.TryConsumeShield())
        {
            return;
        }

        currentHealth -= damage;
        OnDamaged?.Invoke();

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
