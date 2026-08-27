using UnityEngine;
using TMPro;

public class DamageableCanvasHPAndShieldsUITextManager : MonoBehaviour
{
    [SerializeField] private MonoBehaviour damageableSource;
    [SerializeField] private MonoBehaviour shieldableSource;
    [SerializeField] private TMP_Text statusText;

    private IDamageable damageable;
    private IShieldable shieldable;

    private int currentHealth;
    private int maxHealth;
    private int currentShields;
    private int maxShields;

    private void Awake()
    {
        damageable = damageableSource as IDamageable;
        shieldable = shieldableSource as IShieldable;

        currentHealth = damageable.CurrentHealth;
        maxHealth = damageable.MaxHealth;
        currentShields = shieldable.CurrentShields;
        maxShields = shieldable.MaxShields;

        damageable.OnCurrentHealthValueChanged += HandleCurrentHealthChanged;
        damageable.OnMaxHealthValueChanged += HandleMaxHealthChanged;
        shieldable.OnCurrentShieldValueChanged += HandleCurrentShieldChanged;
        shieldable.OnMaxShieldValueChanged += HandleMaxShieldChanged;

        RefreshText();
    }

    private void HandleCurrentHealthChanged(int value)
    {
        currentHealth = value;
        RefreshText();
    }

    private void HandleMaxHealthChanged(int value)
    {
        maxHealth = value;
        RefreshText();
    }

    private void HandleCurrentShieldChanged(int value)
    {
        currentShields = value;
        RefreshText();
    }

    private void HandleMaxShieldChanged(int value)
    {
        maxShields = value;
        RefreshText();
    }

    private void RefreshText()
    {
        statusText.text = $"H{currentHealth}/{maxHealth}   S{currentShields}/{maxShields}";
    }

    private void OnDestroy()
    {
        damageable.OnCurrentHealthValueChanged -= HandleCurrentHealthChanged;
        damageable.OnMaxHealthValueChanged -= HandleMaxHealthChanged;
        shieldable.OnCurrentShieldValueChanged -= HandleCurrentShieldChanged;
        shieldable.OnMaxShieldValueChanged -= HandleMaxShieldChanged;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (damageableSource != null && !(damageableSource is IDamageable))
        {
            Debug.LogError($"{nameof(damageableSource)} on {name} does not implement IDamageable.", this);
        }

        if (shieldableSource != null && !(shieldableSource is IShieldable))
        {
            Debug.LogError($"{nameof(shieldableSource)} on {name} does not implement IShieldable.", this);
        }
    }
#endif
}
