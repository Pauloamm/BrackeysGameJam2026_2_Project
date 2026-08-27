using UnityEngine;
using System;

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
        if (shieldManager.TryConsumeShield()) return;
        

        currentHealth -= damage;
        OnDamaged?.Invoke();

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
