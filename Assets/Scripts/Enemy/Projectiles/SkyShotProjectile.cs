using UnityEngine;
using System;
using System.Collections;

public class SkyShotProjectile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer telegraphVisual;

    private float aoeRadius;
    private int aoeDamage;
    private float telegraphDuration;

    public event Action OnTelegraphStart;
    public event Action OnTelegraphEnd;

    public void Initialize(float radius, int damage, float duration)
    {
        aoeRadius = radius;
        aoeDamage = damage;
        telegraphDuration = duration;

        telegraphVisual.color = Color.red;
        telegraphVisual.transform.localScale = Vector3.one * (aoeRadius * 2f);

        OnTelegraphStart?.Invoke();

        StartCoroutine(TelegraphRoutine());
    }

    private IEnumerator TelegraphRoutine()
    {
        yield return new WaitForSeconds(telegraphDuration);
        Detonate();
    }

    private void Detonate()
    {
        OnTelegraphEnd?.Invoke();

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, aoeRadius);

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
}