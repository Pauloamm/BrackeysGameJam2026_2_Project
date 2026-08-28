using UnityEngine;
using System.Collections;

public class EnemyHitFlashEffect : MonoBehaviour
{
    [SerializeField] private MonoBehaviour damageableSource;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float flashDuration = 0.1f;

    private IDamageable damageable;
    private Color originalColor;
    private Coroutine flashCoroutine;

    private void Awake()
    {
        damageable = (IDamageable)damageableSource;
        originalColor = spriteRenderer.color;

        damageable.OnDamaged += HandleDamaged;
    }

    private void OnDestroy()
    {
        damageable.OnDamaged -= HandleDamaged;
    }

    private void HandleDamaged()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
        flashCoroutine = null;
    }

    private void OnValidate()
    {
        if (damageableSource != null && !(damageableSource is IDamageable))
        {
            Debug.LogError($"{nameof(damageableSource)} on {name} must implement IDamageable.", this);
        }
    }
}