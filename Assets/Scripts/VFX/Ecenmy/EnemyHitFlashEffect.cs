using System.Collections;
using UnityEngine;

public class EnemyHitFlashEffect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite flashSprite;
    [SerializeField] private float totalBlinkDuration = 1f;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private MonoBehaviour damageableSource;

    private Sprite originalSprite;
    private IDamageable damageable;
    private Coroutine activeFlashCoroutine;

    private void Awake()
    {
        damageable = damageableSource as IDamageable;
        originalSprite = spriteRenderer.sprite;
    }

    private void OnEnable()
    {
        if (damageable != null)
        {
            damageable.OnDamaged += HandleDamaged;
        }
    }

    private void OnDisable()
    {
        if (damageable != null)
        {
            damageable.OnDamaged -= HandleDamaged;
        }
    }

    private void HandleDamaged()
    {
        if (activeFlashCoroutine != null)
        {
            StopCoroutine(activeFlashCoroutine);
        }
        activeFlashCoroutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        int blinkCount = Mathf.Max(1, Mathf.RoundToInt(totalBlinkDuration / blinkInterval));
        bool showingFlash = false;

        for (int i = 0; i < blinkCount; i++)
        {
            showingFlash = !showingFlash;
            spriteRenderer.sprite = showingFlash ? flashSprite : originalSprite;
            yield return new WaitForSeconds(blinkInterval);
        }

        spriteRenderer.sprite = originalSprite;
        activeFlashCoroutine = null;
    }
}