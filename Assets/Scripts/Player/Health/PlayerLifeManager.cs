using System;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour, IDamageable
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private ShieldManager shieldManager;
    private int currentHealth;

    private bool isInvincible;

    public event Action OnDeath;
    public event Action OnDamaged;
    public event Action<int> OnCurrentHealthValueChanged;
    public event Action<int> OnMaxHealthValueChanged;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        OnMaxHealthValueChanged?.Invoke(maxHealth);
        OnCurrentHealthValueChanged?.Invoke(currentHealth);
    }

    public void SetMaxHealth(int newMaxHealth, bool healToFull)
    {
        maxHealth = newMaxHealth;
        OnMaxHealthValueChanged?.Invoke(maxHealth);

        if (healToFull)
        {
            HealToFull();
        }
    }

    public void HealToFull()
    {
        currentHealth = maxHealth;
        OnCurrentHealthValueChanged?.Invoke(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible || currentHealth <= 0) return;

        if (shieldManager.TryConsumeShield())
        {
            OnDamaged?.Invoke();
            return;
        }

        currentHealth -= damage;
        OnCurrentHealthValueChanged?.Invoke(currentHealth);
        OnDamaged?.Invoke();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
            return;
        }

        StartInvincibility();
    }

    public void SetInvincible(bool value)
    {
        isInvincible = value;
    }

    private void StartInvincibility()
    {
        isInvincible = true;
    }

    private void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    public void ForceDeath()
    {
        currentHealth = 0;
        Die();
    }
}