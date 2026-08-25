using System;


public interface IDamageable
{
    event Action OnDamaged;
    void TakeDamage(int damage);
}