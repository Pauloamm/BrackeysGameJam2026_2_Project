using UnityEngine;
using System;

public class ShieldManager : MonoBehaviour, IShieldable
{
    [SerializeField] private int maxShields;
    private int currentShields;

    public event Action OnShielded;
    public event Action OnShieldConsumed;
    public event Action<int> OnCurrentShieldValueChanged;
    public event Action<int> OnMaxShieldValueChanged;

    public int CurrentShields => currentShields;
    public int MaxShields => maxShields;

    private void Awake()
    {
        OnMaxShieldValueChanged?.Invoke(maxShields);
        OnCurrentShieldValueChanged?.Invoke(currentShields);
    }

    public void ApplyShield(int amount)
    {
        currentShields = Mathf.Min(currentShields + amount, maxShields);
        OnCurrentShieldValueChanged?.Invoke(currentShields);
        OnShielded?.Invoke();
    }

    public void AddMaxShields(int amount)
    {
        maxShields += amount;
        OnMaxShieldValueChanged?.Invoke(maxShields);
    }

    public bool TryConsumeShield()
    {
        if (currentShields <= 0)
        {
            return false;
        }

        currentShields--;
        OnCurrentShieldValueChanged?.Invoke(currentShields);
        OnShieldConsumed?.Invoke();
        return true;
    }
}