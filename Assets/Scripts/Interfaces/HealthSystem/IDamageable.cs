using System;

public interface IDamageable
{
    event Action OnDamaged;
    event Action<int> OnCurrentHealthValueChanged;
    event Action<int> OnMaxHealthValueChanged;

    int CurrentHealth { get; }
    int MaxHealth { get; }

    void TakeDamage(int damage);
}