using UnityEngine;

public class ShotProjectile : ProjectileBase
{
    private Vector2 direction;
    private int bounceRemaining;
    private int pierceRemaining;

    public void Launch(Vector2 direction, float damage, float projectileSpeed, int bounceCount = 0, int pierceCount = 0)
    {
        this.direction = direction.normalized;
        powerValue = damage;
        speed = projectileSpeed;
        bounceRemaining = bounceCount;
        pierceRemaining = pierceCount;
    }

    protected override void Move()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponentInChildren<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(Mathf.RoundToInt(powerValue));
        }

        if (pierceRemaining > 0)
        {
            pierceRemaining--;
            return;
        }

        if (bounceRemaining > 0)
        {
            Vector2 approximateNormal = ((Vector2)transform.position - (Vector2)other.ClosestPoint(transform.position)).normalized;
            direction = Vector2.Reflect(direction, approximateNormal);
            bounceRemaining--;
            return;
        }

        Destroy(gameObject);
    }
}
