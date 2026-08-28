using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUIManager : MonoBehaviour
{
    [SerializeField] private MonoBehaviour damageableSource;
    [SerializeField] private Image fillImage;
    [SerializeField] private TMP_Text healthText;

    private IDamageable damageable;
    private int maxHealth;

    private void Awake()
    {
        damageable = (IDamageable)damageableSource;

        maxHealth = damageable.MaxHealth;
        RefreshFill(damageable.CurrentHealth);
        RefreshText(damageable.CurrentHealth);

        damageable.OnMaxHealthValueChanged += HandleMaxHealthValueChanged;
        damageable.OnCurrentHealthValueChanged += HandleCurrentHealthValueChanged;
    }

    private void OnDestroy()
    {
        damageable.OnMaxHealthValueChanged -= HandleMaxHealthValueChanged;
        damageable.OnCurrentHealthValueChanged -= HandleCurrentHealthValueChanged;
    }

    private void HandleMaxHealthValueChanged(int newMax)
    {
        maxHealth = newMax;
        RefreshFill(damageable.CurrentHealth);
        RefreshText(damageable.CurrentHealth);
    }

    private void HandleCurrentHealthValueChanged(int newCurrent)
    {
        RefreshFill(newCurrent);
        RefreshText(newCurrent);
    }

    private void RefreshFill(int currentHealth)
    {
        fillImage.fillAmount = maxHealth > 0 ? (float)currentHealth / maxHealth : 0f;
    }

    private void RefreshText(int currentHealth)
    {
        healthText.text = $"{currentHealth}/{maxHealth}";
    }

    private void OnValidate()
    {
        if (damageableSource != null && !(damageableSource is IDamageable))
        {
            Debug.LogError($"{nameof(damageableSource)} on {name} must implement IDamageable.", this);
        }
    }
}