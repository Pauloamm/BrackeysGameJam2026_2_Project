using UnityEngine;

public class EnemyShotProjectile : ProjectileBase
{
    private Vector2 direction;

    public void Launch(Vector2 launchDirection, float launchSpeed, int damage)
    {
        direction = launchDirection;
        speed = launchSpeed;
        powerValue = damage;
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
            damageable.TakeDamage((int)powerValue);
        }

        Destroy(gameObject);
    }
}
