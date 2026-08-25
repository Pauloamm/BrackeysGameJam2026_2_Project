using UnityEngine;

public class AegisOrb : ProjectileBase
{
    private Vector2 direction;

    public void Launch(Vector2 direction, float shieldStrength, float orbSpeed)
    {
        this.direction = direction.normalized;
        powerValue = shieldStrength;
        speed = orbSpeed;
    }

    protected override void Move()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // TODO: grant powerValue shield to the player (interception steals it) once a shield interface exists
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Enemy"))
        {
            // TODO: grant powerValue shield to the enemy once a shield interface exists
            Destroy(gameObject);
        }
    }
}
