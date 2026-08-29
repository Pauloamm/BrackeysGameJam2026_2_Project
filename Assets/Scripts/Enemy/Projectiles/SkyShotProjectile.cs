using UnityEngine;
using System;
using System.Collections;

public class SkyShotProjectile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer telegraphVisual;

    private Vector3 originalScale;
    private float aoeRadius;
    private int aoeDamage;
    private float telegraphDuration;

    public event Action OnTelegraphStart;
    public event Action OnTelegraphEnd;

    private void Awake()
    {
        originalScale = telegraphVisual.transform.localScale;
    }

    public void Initialize(float radius, int damage, float duration)
    {
        aoeRadius = radius;
        aoeDamage = damage;
        telegraphDuration = duration;

        telegraphVisual.color = Color.red;
        telegraphVisual.transform.localScale = Vector3.zero;

        OnTelegraphStart?.Invoke();

        StartCoroutine(ScaleInRoutine());
        StartCoroutine(TelegraphRoutine());
    }

    private IEnumerator ScaleInRoutine()
    {
        Vector3 targetScale = originalScale * aoeRadius;
        float timer = 0f;

        while (timer < telegraphDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / telegraphDuration);
            float eased = Mathf.SmoothStep(0f, 1f, t);
            telegraphVisual.transform.localScale = targetScale * eased;
            yield return null;
        }

        telegraphVisual.transform.localScale = targetScale;
    }

    private IEnumerator TelegraphRoutine()
    {
        yield return new WaitForSeconds(telegraphDuration);
        Detonate();
    }

    private void Detonate()
    {
        OnTelegraphEnd?.Invoke();

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.3f);

        foreach (Collider2D hit in hits)
        {
            IDamageable damageable = hit.GetComponentInChildren<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(aoeDamage);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}