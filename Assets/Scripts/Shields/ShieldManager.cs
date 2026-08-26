using UnityEngine;
using System;

public class ShieldManager : MonoBehaviour, IShieldable
{
    [SerializeField] private int maxShields;
    private int currentShields;

    public event Action OnShielded;
    public event Action OnShieldConsumed;

    public void ApplyShield(int amount)
    {
        currentShields = Mathf.Min(currentShields + amount, maxShields);
        OnShielded?.Invoke();
    }

    public void AddMaxShields(int amount)
    {
        maxShields += amount;
    }

    public bool TryConsumeShield()
    {
        if (currentShields <= 0)
        {
            return false;
        }

        currentShields--;
        OnShieldConsumed?.Invoke();
        return true;
    }
}
