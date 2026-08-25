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
        IShieldable shieldable = other.GetComponentInChildren<IShieldable>();

        if (shieldable != null)
        {
            shieldable.ApplyShield(Mathf.RoundToInt(powerValue));
        }

        Destroy(gameObject);
    }
}