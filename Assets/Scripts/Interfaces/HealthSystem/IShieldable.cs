using System;

public interface IShieldable
{
    event Action OnShielded;
    void ApplyShield(int amount);
}
