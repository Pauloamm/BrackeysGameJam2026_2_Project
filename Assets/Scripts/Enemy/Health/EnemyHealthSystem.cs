using UnityEngine;
using System;

public class EnemyHealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] private ShieldManager shieldManager;

    private int currentHealth;
    private int maxHealth;

    public event Action OnDamaged;
    public event Action OnDeath;
    public event Action<int> OnCurrentHealthValueChanged;
    public event Action<int> OnMaxHealthValueChanged;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    public void Initialize(int maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;

        OnMaxHealthValueChanged?.Invoke(this.maxHealth);
        OnCurrentHealthValueChanged?.Invoke(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (shieldManager.TryConsumeShield()) return;

        currentHealth -= damage;
        OnCurrentHealthValueChanged?.Invoke(currentHealth);
        OnDamaged?.Invoke();

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}