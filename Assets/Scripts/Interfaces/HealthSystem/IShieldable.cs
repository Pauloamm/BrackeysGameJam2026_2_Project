using System;

public interface IShieldable
{
    event Action OnShielded;
    event Action<int> OnCurrentShieldValueChanged;
    event Action<int> OnMaxShieldValueChanged;

    int CurrentShields { get; }
    int MaxShields { get; }

    void ApplyShield(int amount);
}