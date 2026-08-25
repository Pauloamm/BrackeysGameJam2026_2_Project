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
        if (other.CompareTag("Player"))
        {
            // TODO: deal powerValue damage to the player once a health/damage interface exists
            Destroy(gameObject);
            return;
        }

        if (pierceRemaining > 0)
        {
            // TODO: deal powerValue damage to the enemy once a health/damage interface exists
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
